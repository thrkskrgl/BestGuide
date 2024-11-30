using BestGuide.Common.Pagination;
using BestGuide.Report.Domain.Args.HotelReportArgs;
using BestGuide.Report.Domain.Events;
using BestGuide.Report.Domain.Models;
using BestGuide.Report.Domain.Persistence;
using MediatR;

namespace BestGuide.Report.Domain.Services
{
    public class HotelReportService : IHotelReportService
    {
        private readonly IHotelReportRepository _hotelReportRepository;
        private readonly IMediator _mediator;

        public HotelReportService(IHotelReportRepository hotelReportRepository, IMediator mediator)
        {
            _hotelReportRepository = hotelReportRepository;
            _mediator = mediator;
        }

        public async Task<Guid> CreateAsync(CreateHotelReportArgs args, CancellationToken cancellationToken = default)
        {
            var entity = args.New();
            entity = await _hotelReportRepository.AddAsync(entity, cancellationToken);

            if (entity is null)
            {
                throw new InvalidOperationException();
            }

            var message = new HotelReportCreated
            {
                Id = entity.Id,
                Location = args.Location
            };
            await _mediator.Publish(message, cancellationToken);

            return entity.Id;
        }

        public async Task UpdateAsync(UpdateHotelReportArgs args, CancellationToken cancellationToken = default)
        {
            var entity = await _hotelReportRepository.GetAsync(new GetHotelReportByIdArgs { Id = args.Id }, cancellationToken);
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            entity = args.Modify(entity);
            await _hotelReportRepository.UpdateAsync(entity, cancellationToken);
        }

        public async Task<HotelReport> GetAsync(GetHotelReportByIdArgs args, CancellationToken cancellationToken = default)
        {
            return await _hotelReportRepository.GetAsync(args, cancellationToken);
        }

        public async Task<IList<HotelReport>> ListAsync(SearchHotelReportArgs args, CancellationToken cancellationToken = default)
        {
            return await _hotelReportRepository.ListAsync(args, cancellationToken);
        }

        public async Task<IListPaged<HotelReport>> ListPagedAsync(SearchHotelReportArgs args, CancellationToken cancellationToken = default)
        {
            return await _hotelReportRepository.ListPagedAsync(args, cancellationToken);
        }
    }
}
