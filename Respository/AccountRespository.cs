using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using System.Threading.Tasks;
using WebApplicationIdentity.Models;
using WebApplicationIdentity.Services;

namespace WebApplicationIdentity.Respository
{
    public class AccountRespository: IAccountRespository
    {
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserServices _userServices;


        public AccountRespository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IUserServices UserServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userServices= UserServices;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel request)
        {
            //var user = new IdentityUser
            //{
            //    UserName = request.Email,
            //    NormalizedUserName = request.Email,
            //    Email = request.Email,
            //    EmailConfirmed = true,



            //};
            var user = new ApplicationUser
            {
               FirstName=request.FirstName,
               LastName=request.LastName,
                UserName = request.Email,
                NormalizedUserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true,



            };
            var result =await _userManager.CreateAsync(user, request.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result;
        }
        public async Task<SignInResult> PasswordSignInAsync(UserLoginDto login)
        {
           var result=await _signInManager.PasswordSignInAsync(login.Email,login.Password,login.RememberMe,false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> ChangePasswordAsync(ChangePassword model)
        {
            var userId = _userServices.GetUserId();
            var user=await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            return result;
        }
    }
}
