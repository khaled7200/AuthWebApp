using AuthWebApplication.Models.Uow;
using AuthWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AuthWebApplication.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Login()
        {
           
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
