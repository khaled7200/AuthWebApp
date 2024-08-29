using AuthWebApplication.Models;
using AuthWebApplication.Models.Uow;
using AuthWebApplication.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AuthWebApplication.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(IUnitOfWork unitOfWork,SignInManager<AppUser> signInManager)
        {
            this.unitOfWork = unitOfWork;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            var res =await unitOfWork.AuthService.Login(loginView);
            if (res.Succeeded) { return RedirectToAction("Index", "Home"); }
            else
            {
           
                    ModelState.AddModelError(string.Empty,"Inavlid Username Or Password !!!");
                return View();
            }
            
        }

        public IActionResult Register()
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerView)
            {
          var res=await  unitOfWork.AuthService.Register(registerView);

            if (res.Succeeded) { return RedirectToAction("Login"); }
            else
            {
                foreach (var item in res.Errors)
                {

                    ModelState.AddModelError(string.Empty, item.Description);

                }
                return View();
            }

            
            }
        public async Task<IActionResult> Logout()
        {

            await unitOfWork.AuthService.LogOut();
           return RedirectToAction("Index", "Home");
        }

        }
}
