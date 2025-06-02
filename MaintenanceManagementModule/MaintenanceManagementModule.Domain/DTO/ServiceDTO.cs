namespace MaintenanceManagementModule.Domain.DTO
{
    public class ServiceDTO : BaseDTO
    {
        public string? ServiceName { get; set; }
        public DateTime ServiceDate { get; set; }
    }

    public class ServiceValidator : AbstractValidator<ServiceDTO>
    {
        public ServiceValidator()
        {
            RuleFor(e => e.ServiceName).NotEmpty().WithMessage("Service name is required");
            RuleFor(e => e.ServiceName).MaximumLength(100).WithMessage("Maximum 100 characters allowed");
            RuleFor(e => e.ServiceDate).Must(date => date.Date >= DateTime.Today).WithMessage("Date must be today or in the future.");
        }
    }
}