﻿using AutoMapper;
using BestGuide.Report.Application.Commands;
using BestGuide.Report.Application.Queries;
using BestGuide.Report.Areas.HotelReport.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BestGuide.Report.Areas.Report
{
    /// <summary>
    /// HotelReportController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HotelReportController : ControllerRoot
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// HotelReportController Ctor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public HotelReportController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Create A Hotel Report (Report uuid returns)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(HotelReportCreateResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateHotelReport([FromBody] CreateHotelReportRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<CreateHotelReportCommand>(request);

            var result = await _mediator.Send(query, cancellationToken);

            if (result.Equals(default))
            {
                return ServerError();
            }

            return Ok(new HotelReportCreateResponse { Id = result });
        }

        /// <summary>
        /// Get Report With Details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HotelReportDetailResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReport([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetHotelReportByIdQuery() { Id = id };

            var result = await _mediator.Send(query, cancellationToken);

            if (result is null)
            {
                return NotFound();
            }

            var response = _mapper.Map<HotelReportDetailResponse>(result);
            return Ok(response);
        }

        /// <summary>
        /// Get Reports With Status
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("hotel-reports")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HotelReportResponse[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHotelReports([FromQuery] SearchHotelReportsRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<SearchHotelReportsQuery>(request);

            var result = await _mediator.Send(query, cancellationToken);

            if (result is null || result.Count == 0)
            {
                return NotFound();
            }

            var response = _mapper.Map<HotelReportResponse[]>(result);
            return Ok(response);
        }

        /// <summary>
        /// Get Paged Reports With Status
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("paged-hotel-reports")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HotelReportResponse[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPagedHotels([FromQuery] SearchPagedHotelReportsRequest request, CancellationToken cancellationToken)
        {
            SetRequestPageHeaders(request);
            var query = _mapper.Map<PagedSearchHotelReportsQuery>(request);

            var result = await _mediator.Send(query, cancellationToken);

            if (result is null || result.TotalCount == 0)
            {
                return NotFound();
            }

            SetResponsePageHeaders(result);
            var response = _mapper.Map<HotelReportResponse[]>(result.Items);
            return Ok(response);
        }
    }
}
