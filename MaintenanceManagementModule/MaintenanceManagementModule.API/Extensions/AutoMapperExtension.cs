namespace MaintenanceManagementModule.API.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {           
            services.AddAutoMapper(typeof(ProfileMapper).Assembly);

            return services;
        }
    }
}
