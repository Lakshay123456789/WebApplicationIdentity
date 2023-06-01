using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationIdentity.Models;
using WebApplicationIdentity.Respository;

namespace WebApplicationIdentity.Controllers
{
    public class AccountController : Controller
    {

        // private readonly UserManager<IdentityUser> userManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAccountRespository _accountRespository;
        public AccountController(UserManager<ApplicationUser> userManager, IAccountRespository accountRespository)
        {
            this.userManager = userManager;

            this._accountRespository= accountRespository;
      
        }
        [HttpGet]
        public IActionResult Index()
        {
            SignUpUserModel model = new SignUpUserModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(SignUpUserModel request)
        {
            if (ModelState.IsValid)
            {
                var UserCheck = await userManager.FindByEmailAsync(request.Email);
                if (UserCheck == null)
                {
                    //var user = new IdentityUser
                    //{
                    //  UserName=request.Email,
                    //  NormalizedUserName=request.Email,
                    //  Email=request.Email,
                    // EmailConfirmed=true,



                    //};
                    //        var result = await userManager.CreateAsync(user, request.Password);
                    var result = await _accountRespository.CreateUserAsync(request);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (!result.Succeeded)
                        {
                            foreach(var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email already exists.");
                    return View(request);
                }
            }
            return View(request);
        }
        [HttpGet]
        public IActionResult Login()
        {
            UserLoginDto model = new UserLoginDto();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result =await _accountRespository.PasswordSignInAsync(model);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "students");
                }
              
               
            }
            ModelState.AddModelError("", "Invalid credentials");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountRespository.SignOutAsync();
            return RedirectToAction("login", "account");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            var changePassword = new ChangePassword();
            return View(changePassword);
        }
        [HttpPost]

        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                var result=await _accountRespository.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuceess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
