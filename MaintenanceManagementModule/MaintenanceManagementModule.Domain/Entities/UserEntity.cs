namespace MaintenanceManagementModule.Domain.Entities
{
    public class UserEntity : IdentityUser
    {
        public string FullName { get; set; }
    }
}
