namespace AuthWebApplication.Models.Uow.IRep
{
    public interface IUserService
    {
        public Task<string> GetUserImage(string UserId);
    }
}
