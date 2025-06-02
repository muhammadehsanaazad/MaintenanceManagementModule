namespace MaintenanceManagementModule.API.Extensions
{
    public static class ExceptionFilterExtension
    {
        public static IServiceCollection AddExceptionFilter(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });

            return services;
        }
    }
}
