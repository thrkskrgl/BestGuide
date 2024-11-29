using BestGuide.Common.Pagination;
using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Models;
using BestGuide.Modules.Domain.Persistence;

namespace BestGuide.Modules.Domain.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IRepositoryFactory repositoryFactory)
        {
            _hotelRepository = repositoryFactory.GetHotelRepository();
        }

        public async Task<Hotel> CreateAsync(CreateHotelArgs args, CancellationToken cancellationToken = default)
        {
            Hotel entity;
            try
            {
                entity = args.New();
                await _hotelRepository.AddAsync(entity, cancellationToken);
                return entity;
            }
            catch (Exception)
            {
                //rollback
                throw;
            }
        }

        public async Task DeleteAsync(DeleteHotelArgs args, CancellationToken cancellationToken = default)
        {
            var entity = await _hotelRepository.GetAsync(new GetHotelByIdArgs { Id = args.Id }, cancellationToken);
            try
            {
                if (entity is null)
                {
                    return;
                }

                await _hotelRepository.DeleteAsync(entity, cancellationToken);
            }
            catch (Exception)
            {
                //rollback
                throw;
            }
        }

        public async Task<Hotel> GetAsync(GetHotelByIdArgs args, CancellationToken cancellationToken = default)
        {
            return await _hotelRepository.GetAsync(args, cancellationToken);
        }

        public async Task<IList<Hotel>> ListAsync(SearchHotelArgs args, CancellationToken cancellationToken = default)
        {
            return await _hotelRepository.ListAsync(args, cancellationToken);
        }

        public async Task<IListPaged<Hotel>> ListPagedAsync(SearchHotelArgs args, CancellationToken cancellationToken = default)
        {
            return await _hotelRepository.ListPagedAsync(args, cancellationToken);
        }
    }
}
