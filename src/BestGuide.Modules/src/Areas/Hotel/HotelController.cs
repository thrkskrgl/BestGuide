using AutoMapper;
using BestGuide.Modules.Application.Hotels.Commands;
using BestGuide.Modules.Application.Hotels.Queries;
using BestGuide.Modules.Areas.Hotel.Models.Requests;
using BestGuide.Modules.Areas.Hotel.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BestGuide.Modules.Areas.Hotel
{
    /// <summary>
    /// Hotel Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerRoot
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Hotel Controller Ctor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public HotelController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Hotel Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HotelResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHotel([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetHotelsByIdQuery() { Id = id };

            var result = await _mediator.Send(query, cancellationToken);

            if (result is null)
            {
                return NotFound();
            }

            var response = _mapper.Map<HotelResponse>(result);
            return Ok(response);
        }

        /// <summary>
        /// Get Hotels Method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("hotels")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HotelResponse[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHotels([FromQuery] SearchHotelsRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<SearchHotelsQuery>(request);

            var result = await _mediator.Send(query, cancellationToken);

            if (result is null || result.Count == 0)
            {
                return NotFound();
            }

            var response = _mapper.Map<HotelResponse[]>(result);
            return Ok(response);
        }

        /// <summary>
        /// Get Paged Hotels Method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("paged-hotels")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HotelResponse[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPagedHotels([FromQuery] SearchPagedHotelsRequest request, CancellationToken cancellationToken)
        {
            SetRequestPageHeaders(request);
            var query = _mapper.Map<PagedSearchHotelsQuery>(request);

            var result = await _mediator.Send(query, cancellationToken);

            if (result is null || result.TotalCount == 0)
            {
                return NotFound();
            }

            SetResponsePageHeaders(result);
            var response = _mapper.Map<HotelResponse[]>(result.Items);
            return Ok(response);
        }

        /// <summary>
        /// Create Hotel Method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(HotelResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<CreateHotelCommand>(request);

            var result = await _mediator.Send(query, cancellationToken);

            if (result is null)
            {
                return ServerError();
            }

            var response = _mapper.Map<HotelResponse>(result);
            return Ok(response);
        }

        /// <summary>
        /// Hard Delete Hotel Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteHotel([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new DeleteHotelCommand() { Id = id };

            await _mediator.Send(query, cancellationToken);

            return Ok();
        }
    }
}
