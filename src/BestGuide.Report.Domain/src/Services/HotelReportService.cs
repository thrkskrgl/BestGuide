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

        /// <summary>
        /// Create InProgress Report and Throw an HotelReportCreated Event
        /// </summary>
        /// <param name="args"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Guid> CreateAsync(CreateHotelReportArgs args, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = args.New();
                await _hotelReportRepository.BeginTransactionAsync(cancellationToken);
                entity = await _hotelReportRepository.AddAsync(entity, cancellationToken);

                ArgumentNullException.ThrowIfNull(entity);

                var message = new HotelReportCreated
                {
                    Id = entity.Id,
                    Location = args.Location
                };
                await _mediator.Publish(message, cancellationToken);

                await _hotelReportRepository.CommitTransactionAsync(cancellationToken);
                return entity.Id;
            }
            catch (Exception)
            {
                await _hotelReportRepository.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }

        /// <summary>
        /// To update the report content with a update message 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateHotelReportArgs args, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(args);
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
