namespace MaintenanceManagementModule.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<UserEntity>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ServiceEntity> Service { get; set; }
        public DbSet<TaskEntity> Task { get; set; }
    }
}
