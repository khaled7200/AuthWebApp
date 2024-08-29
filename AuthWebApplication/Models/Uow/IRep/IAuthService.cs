using AuthWebApplication.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AuthWebApplication.Models.Uow.IRep
{
    public interface IAuthService
    {
        public Task<SignInResult> Login(LoginViewModel loginVM);

        public Task<IdentityResult> Register(RegisterViewModel registerVM);

        public Task<bool> LogOut();

    }
}
