using AutoMapper;
using Cinema.Application.Cinema.Commands.CreateSeat;
using Cinema.Application.Cinema.Commands.CreateTicket;
using Cinema.Application.Cinema.Commands.DeleteSeat;
using Cinema.Application.Cinema.Commands.DeleteTicket;
using Cinema.Application.Cinema.Commands.UpdateSeat;
using Cinema.Application.Cinema.Commands.UpdateTicket;
using Cinema.Application.Cinema.Queries.GetSeat;
using Cinema.Application.Cinema.Queries.GetSeats;
using Cinema.Application.Cinema.Queries.GetTicket;
using Cinema.Application.Cinema.Queries.GetTickets;
using Cinema.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : BaseController
    {
        private readonly IMapper _mapper;

        public TicketController(IMapper mapper) => _mapper = mapper;


        [HttpGet]
        public async Task<ActionResult<TicketLookupDto>> GetAll()
        {
            var query = new GetTicketListQuery();

            var vm = await Mediator.Send(query);

            return vm;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<TicketDetailsVm>> Get([FromRoute] Guid id)
        {
            var query = new GetTicketQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return vm;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTicketDto _commaand)
        {
            var command = _mapper.Map<CreateTicketCommand>(_commaand);

            var seatId = await Mediator.Send(command);

            return Ok(seatId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTicketDto updateTicketDto)
        {
            var command = _mapper.Map<UpdateTicketCommand>(updateTicketDto);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTicketCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
