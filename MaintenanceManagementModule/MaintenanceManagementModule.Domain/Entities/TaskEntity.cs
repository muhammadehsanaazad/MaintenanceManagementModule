namespace MaintenanceManagementModule.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string TaskName { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
        public Guid ServiceId { get; set; }
        public virtual ServiceEntity Service { get; set; }
    }
}
