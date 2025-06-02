namespace MaintenanceManagementModule.Domain.DTO
{
    public class TaskDTO : BaseDTO
    {
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
        public Guid? UpdatedById { get; set; }
        public Guid ServiceId { get; set; }
    }

    public class TaskValidator : AbstractValidator<TaskDTO>
    {
        public TaskValidator()
        {
            RuleFor(e => e.TaskName).NotEmpty().WithMessage("Task name is required");
            RuleFor(e => e.TaskName).MaximumLength(100).WithMessage("Maximum 100 characters allowed");
        }
    }
}
