namespace MaintenanceManagementModule.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties

        protected AppDbContext _appDbContext { get; set; }
        protected Dictionary<Type, object> _repository;
        #endregion

        #region Constructor

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion

        #region Public Methods

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
        #endregion

        #region Repository

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            var type = typeof(T);

            if (_repository is null)
                _repository = new Dictionary<Type, object>();

            if (!_repository.ContainsKey(type))
                _repository[type] = new Repository<T>(_appDbContext);

            return (IRepository<T>)_repository[type];
        }
        #endregion
    }
}
