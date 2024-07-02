using AutoMapper;
using Cinema.Application.Cinema.Commands.CreateSeat;
using Cinema.Application.Cinema.Commands.DeleteSeat;
using Cinema.Application.Cinema.Commands.UpdateSeat;
using Cinema.Application.Cinema.Queries.GetSeat;
using Cinema.Application.Cinema.Queries.GetSeats;
using Cinema.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : BaseController
    {
        private readonly IMapper _mapper;

        public SeatController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<SeatListVm>> GetAll()
        {
            var query = new GetSeatListQuery();

            var vm = await Mediator.Send(query);

            return vm;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<SeatDetailsVm>> Get([FromRoute] Guid id)
        {
            var query = new GetSeatDetailsQuery { 
                Id = id
            };

            var vm = await Mediator.Send(query);

            return vm;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSeatDto request)
        {
            var command = _mapper.Map<CreateSeatCommand>(request);

            var seatId = await Mediator.Send(command);

            return Ok(seatId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateSeatDto updateSeatDto)
        {
            var command = _mapper.Map<UpdateSeatCommand>(updateSeatDto);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteSeatCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
