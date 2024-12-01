using AutoMapper;
using BestGuide.Modules.Application.HotelContacts.Commands;
using BestGuide.Modules.Areas.HotelContact.Models.Requests;
using BestGuide.Modules.Areas.HotelContact.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BestGuide.Modules.Areas.HotelContact
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelContactController : ControllerRoot
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HotelContactController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(HotelContactResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateHotelContact([FromBody] CreateHotelContactRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<CreateHotelContactCommand>(request);

            var result = await _mediator.Send(query, cancellationToken);

            if (result is null)
            {
                return ServerError();
            }

            var response = _mapper.Map<HotelContactResponse>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteHotelContact([FromRoute] int id, CancellationToken cancellationToken)
        {
            var query = new DeleteHotelContactCommand() { Id = id };

            await _mediator.Send(query, cancellationToken);

            return Ok();
        }
    }
}
