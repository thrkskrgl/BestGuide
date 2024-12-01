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
            ArgumentNullException.ThrowIfNull(args);
            var entity = args.New();
            entity = await _hotelRepository.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(DeleteHotelArgs args, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(args);
            var entity = await _hotelRepository.GetAsync(new GetHotelByIdArgs { Id = args.Id }, cancellationToken);
            if (entity is null)
            {
                return;
            }

            await _hotelRepository.DeleteAsync(entity, cancellationToken);
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

        public async Task PrepareReportAsync(PrepareHotelReportArgs args, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(args);

            var searchArgs = new SearchHotelArgs
            {
                ContactType = args.ContactType,
                ContactContent = args.ContactContent
            };

            var list = await _hotelRepository.ListAsync(searchArgs, cancellationToken);
            if (list?.Any() == false)
            {
                return;
            }

            var message = new HotelReportUpdated
            {
                Id = args.ReportId.Value,
                HotelCount = list.Count,
                TelephoneCount = list.Sum(h => h.Contacts?.Count(c => c.Type == Enums.HotelContactType.Telephone) ?? 0)
            };

            await _mediator.Publish(message, cancellationToken);
        }
    }
}
