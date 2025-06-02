namespace MaintenanceManagementModule.Application.Interfaces
{
    public interface IUserService
    {
        public Guid? GetUserId();
        public Task<UserEntity?> GetUser(string email);
        public Task<IList<string>> GetUserRoles(string email);
    }
}
