using BestGuide.Modules.Domain.Persistence;

namespace BestGuide.Modules.Infrastructure.Persistence
{
    public partial class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ModulesDbContext _dbContext;
        private bool _disposed;

        public RepositoryFactory(IServiceProvider serviceProvider, ModulesDbContext dbContext)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IHotelRepository GetHotelRepository()
        {
            return new HotelRepository(_dbContext);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _dbContext?.Dispose();
            }

            _disposed = true;
        }
    }
}
