using BestGuide.Report.Domain.Persistence;

namespace BestGuide.Report.Domain.Persistence
{
    public partial interface IRepositoryFactory : IDisposable
    {
        IHotelReportRepository GetHotelReportRepository();
    }
}
