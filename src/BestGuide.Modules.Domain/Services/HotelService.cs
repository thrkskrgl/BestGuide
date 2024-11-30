using BestGuide.Common.Pagination;
using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Models;
using BestGuide.Modules.Domain.Persistence;
using BestGuide.Modules.Domain.Events;
using MediatR;

namespace BestGuide.Modules.Domain.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMediator _mediator;

        public HotelService(IRepositoryFactory repositoryFactory, IMediator mediator)
        {
            _hotelRepository = repositoryFactory.GetHotelRepository();
            _mediator = mediator;
        }

        public async Task<Hotel> CreateAsync(CreateHotelArgs args, CancellationToken cancellationToken = default)
        {
            Hotel entity;
            try
            {
                entity = args.New();
                entity = await _hotelRepository.AddAsync(entity, cancellationToken);
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
            var reportDemand = args.ReportId.HasValue;
            var hotels = await _hotelRepository.ListAsync(args, cancellationToken);
            if (hotels.Count == 0)
            {
                return default;
            }

            if (reportDemand)
            {
                var message = new HotelReportUpdated
                {
                    Id = args.ReportId.Value,
                    HotelCount = hotels.Count,
                    TelephoneCount = hotels.Sum(h => h.Contacts?.Count(c => c.Type == Enums.HotelContactType.Telephone) ?? 0)
                };
                await _mediator.Publish(message, cancellationToken);
                return default;
            }

            return hotels;
        }

        public async Task<IListPaged<Hotel>> ListPagedAsync(SearchHotelArgs args, CancellationToken cancellationToken = default)
        {
            return await _hotelRepository.ListPagedAsync(args, cancellationToken);
        }
    }
}
