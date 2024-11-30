using BestGuide.Report.Domain.Persistence;

namespace BestGuide.Report.Infrastructure.Persistence
{
    public partial class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ReportDbContext _dbContext;
        private bool _disposed;

        public RepositoryFactory(IServiceProvider serviceProvider, ReportDbContext dbContext)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IHotelReportRepository GetHotelReportRepository()
        {
            return new HotelReportRepository(_dbContext);
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
