using BestGuide.Common.Pagination;
using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Models;

namespace BestGuide.Modules.Domain.Services
{
    public interface IHotelService
    {
        public Task<Hotel> GetAsync(GetHotelByIdArgs args, CancellationToken cancellationToken = default);
        public Task<IList<Hotel>> ListAsync(SearchHotelArgs args, CancellationToken cancellationToken = default);
        public Task<IListPaged<Hotel>> ListPagedAsync(SearchHotelArgs args, CancellationToken cancellationToken = default);
        public Task<Hotel> CreateAsync(CreateHotelArgs args, CancellationToken cancellationToken = default);
        public Task DeleteAsync(DeleteHotelArgs args, CancellationToken cancellationToken = default);
    }
}
