using BestGuide.Common.EFCore;
using BestGuide.Common.Pagination;
using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Models;

namespace BestGuide.Modules.Domain.Persistence
{
    public interface IHotelRepository : IRepositoryBase<Hotel>
    {
        Task<Hotel> GetAsync(GetHotelByIdArgs args, CancellationToken cancellationToken = default);
        Task<IList<Hotel>> ListAsync(SearchHotelArgs args, CancellationToken cancellationToken = default);
        Task<IListPaged<Hotel>> ListPagedAsync(SearchHotelArgs args, CancellationToken cancellationToken = default);
    }
}
