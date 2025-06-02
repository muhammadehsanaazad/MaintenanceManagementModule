namespace MaintenanceManagementModule.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
