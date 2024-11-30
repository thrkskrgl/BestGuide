using BestGuide.Modules.Domain.Args.HotelContactArgs;
using BestGuide.Modules.Domain.Models;

namespace BestGuide.Modules.Domain.Services
{
    public interface IHotelContactService
    {
        public Task<HotelContact> CreateAsync(CreateHotelContactArgs args, CancellationToken cancellationToken = default);
        public Task DeleteAsync(DeleteHotelContactArgs args, CancellationToken cancellationToken = default);
    }
}
