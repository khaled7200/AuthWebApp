using AuthWebApplication.Models.Uow.IRep;
using AuthWebApplication.Models.Uow.Rep;

namespace AuthWebApplication.Models.Uow
{
    public interface IUnitOfWork
    {
        public IAuthService AuthService { get; }
        public IUserService UserService { get; }
    }
}
