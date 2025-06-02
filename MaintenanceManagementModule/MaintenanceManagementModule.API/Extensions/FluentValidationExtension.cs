namespace MaintenanceManagementModule.API.Extensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ServiceValidator>();
            services.AddValidatorsFromAssemblyContaining<TaskValidator>();

            return services;
        }
    }
}
