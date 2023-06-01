using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Respository
{
    public interface IAccountRespository
    {
     Task<IdentityResult> CreateUserAsync(SignUpUserModel request);
        Task<SignInResult> PasswordSignInAsync(UserLoginDto login);

        Task SignOutAsync();

        Task<IdentityResult> ChangePasswordAsync(ChangePassword model);
    }
}
