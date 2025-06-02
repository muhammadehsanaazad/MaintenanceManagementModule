namespace MaintenanceManagementModule.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Properties

        protected AppDbContext _appDbContext { get; set; }
        #endregion

        #region Constructor

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion

        #region Public Methods
        public async Task AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _appDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _appDbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _appDbContext.Set<T>().Update(entity));
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _appDbContext.Set<T>().Remove(entity));
        }
        #endregion
    }
}
