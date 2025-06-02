namespace MaintenanceManagementModule.API.Extensions
{
    public class RegisterServices
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IResponseService, ResponseService>();

            serviceCollection.AddScoped<IAuthService, AuthService>();
            serviceCollection.AddScoped<ITaskService, TaskService>();
            serviceCollection.AddScoped<IServiceService, ServiceService>();
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}
