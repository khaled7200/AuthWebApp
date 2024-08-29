using AuthWebApplication.Models.Db_Context;
using AuthWebApplication.Models.Uow.IRep;
using AuthWebApplication.Models.Uow.Rep;
using Microsoft.AspNetCore.Identity;

namespace AuthWebApplication.Models.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private IWebHostEnvironment hostEnvironment;
        public UnitOfWork(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment hostEnvironment)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.hostEnvironment = hostEnvironment;
        }

        public IAuthService AuthService { get => new AuthService(appDbContext,userManager,signInManager,hostEnvironment); }
    }
}
