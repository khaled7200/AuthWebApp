using AuthWebApplication.Helpers;
using AuthWebApplication.Models.Db_Context;
using AuthWebApplication.Models.Uow.IRep;
using AuthWebApplication.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthWebApplication.Models.Uow.Rep
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
       private IWebHostEnvironment hostEnvironment;
        public AuthService(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment hostEnvironment)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task<SignInResult> Login(LoginViewModel loginVM)
        {
            try
            {
                AppUser appUser = await appDbContext.Users.Where(y => y.UserName == loginVM.EmailOrEmail
                || y.Email == loginVM.EmailOrEmail).FirstAsync();
              return await  signInManager.PasswordSignInAsync(appUser,loginVM.Password,true,false);
            }
            catch (Exception e)
            {

                return new SignInResult() { };

            }
        }

        public async Task<bool> LogOut()
        {
            try
            {
            await    signInManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {return false;

            }
        }

        public async Task<IdentityResult> Register(RegisterViewModel registerVM)
        {
            try
            {
          var str= await  new ImageManager(hostEnvironment: hostEnvironment).SavePhotoAsync(registerVM.ImageFile, registerVM.Username);
                var user =new AppUser() { Email=registerVM.Email,UserName=registerVM.Username,ImagePath=str};
            return  await  userManager.CreateAsync(user, registerVM.Password);

            }
            catch (Exception)
            {

           return new IdentityResult() { }; 
            }
        }
    }
}
