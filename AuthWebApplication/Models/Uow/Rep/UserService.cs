using AuthWebApplication.Models.Db_Context;
using AuthWebApplication.Models.Uow.IRep;

namespace AuthWebApplication.Models.Uow.Rep
{
    public class UserService : IUserService

    {
        private readonly AppDbContext appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<string> GetUserImage(string UserId)
        {
            try
            {
              var img=  appDbContext.Users.Where(y=>y.Id==UserId)
                    .AsQueryable().First().ImagePath;
              await  Task.Delay(1);
                return img;
            }
            catch (Exception)
            {

                return "";
            }
        }
    }
}
