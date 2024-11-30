using BestGuide.Modules.Domain.Args.HotelContactArgs;
using BestGuide.Modules.Domain.Models;
using BestGuide.Modules.Domain.Persistence;

namespace BestGuide.Modules.Domain.Services
{
    public class HotelContactService : IHotelContactService
    {
        private readonly IHotelContactRepository _hotelContactRepository;

        public HotelContactService(IRepositoryFactory repositoryFactory)
        {
            _hotelContactRepository = repositoryFactory.GetHotelContactRepository();
        }

        public async Task<HotelContact> CreateAsync(CreateHotelContactArgs args, CancellationToken cancellationToken = default)
        {
            var entity = args.New();
            await _hotelContactRepository.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(DeleteHotelContactArgs args, CancellationToken cancellationToken = default)
        {
            var entity = await _hotelContactRepository.GetAsync(x => x.Id == args.Id, cancellationToken: cancellationToken);
            if (entity is null)
            {
                return;
            }
            
            await _hotelContactRepository.DeleteAsync(entity, cancellationToken);
        }
    }
}
