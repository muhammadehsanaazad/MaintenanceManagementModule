namespace MaintenanceManagementModule.Domain.Entities
{
    public class ServiceEntity : BaseEntity
    {
        public string ServiceName { get; set; }
        public DateTime ServiceDate { get; set; }
        public virtual ICollection<TaskEntity> Task { get; set; }
    }
}
