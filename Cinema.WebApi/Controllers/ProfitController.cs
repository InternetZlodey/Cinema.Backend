using AutoMapper;
using Cinema.Application.Cinema.Commands.CreateProfit;
using Cinema.Application.Cinema.Commands.DeleteHall;
using Cinema.Application.Cinema.Commands.DeleteProfit;
using Cinema.Application.Cinema.Commands.UpdateProfit;
using Cinema.Application.Cinema.Queries.GetProfit;
using Cinema.Application.Cinema.Queries.GetProfits;
using Cinema.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfitController : BaseController
    {
        private readonly IMapper _mapper;

        public ProfitController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<ProfitDetailsVm>> Get([FromRoute] Guid id)
        {
            var query = new GetProfitQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<ProfitLookupDto>> GetAll()
        {
            var query = new GetProfitListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProfitDto createProfitDto)
        {
            var command = _mapper.Map<CreateProfitCommand>(createProfitDto);

            var profitId = await Mediator.Send(command);

            return Ok(profitId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateProfitDto updateProfitDto)
        {
            var command = _mapper.Map<UpdateProfitCommand>(updateProfitDto);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteProfitCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }

    }
}
