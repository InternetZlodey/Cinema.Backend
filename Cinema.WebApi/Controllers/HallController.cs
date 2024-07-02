using AutoMapper;
using Cinema.Application.Cinema.Commands.CreateHall;
using Cinema.Application.Cinema.Commands.DeleteHall;
using Cinema.Application.Cinema.Commands.UpdateHall;
using Cinema.Application.Cinema.Queries.GetHall;
using Cinema.Application.Cinema.Queries.GetHalls;
using Cinema.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HallController : BaseController
    {
        private readonly IMapper _mapper;

        public HallController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<HallDetailsVm>> GetHall([FromRoute] Guid id)
        {
            var query = new GetHallDetailsQuery { 
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<HallListDetailsVm>> GetHalls()
        {
            var query = new GetHallsQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateHallDto createHallDto)
        {
            var command = _mapper.Map<CreateHallCommand>(createHallDto);

            var hallId = await Mediator.Send(command);

            return Ok(hallId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateHallDto updateHallDto)
        {
            var command = _mapper.Map<UpdateHallCommand>(updateHallDto);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteHallCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
