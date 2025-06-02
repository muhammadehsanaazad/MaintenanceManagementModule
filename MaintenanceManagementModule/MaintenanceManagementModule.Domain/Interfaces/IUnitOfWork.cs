namespace MaintenanceManagementModule.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveAsync();
    }
}
