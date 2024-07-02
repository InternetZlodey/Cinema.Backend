using Cinema.Application.Cinema.Commands.CreateFilm;
using Cinema.Application.Cinema.Commands.DeleteFilm;
using Cinema.Application.Cinema.Commands.UpdateFilm;
using Cinema.Application.Cinema.Queries.GetFilm;
using Cinema.Application.Cinema.Queries.GetFilm.ByName;
using Cinema.Application.Cinema.Queries.GetFilms;
using Cinema.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Cinema.Application.Cinema.Queries.GetFilm.ByGenre;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FilmController : BaseController
    {
        private readonly IMapper _mapper;

        public FilmController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<FilmListVm>> GetAll()
        {
            var query = new GetFilmListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<FilmDetailsVm>> Get([FromRoute] Guid id)
        {
            var query = new GetFilmDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet]
        [Route("ByName")]
        public async Task<ActionResult<FilmList>> GetByName([FromBody] GetFilmByNameQuery request)
        {
            var query = new GetFilmByNameQuery
            {
                Name = request.Name
            };

            var films = await Mediator.Send(query);

            return Ok(films);
        }

        [HttpGet]
        [Route("ByGenre")]
        public async Task<ActionResult<FilmList>> GetByGenre([FromBody] GetFilmByGenreQuery request)
        {
            var query = new GetFilmByGenreQuery
            {
                Genre = request.Genre
            };

            var films = await Mediator.Send(query);

            return films;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFilmDto createFilmDto)
        {
            var command = _mapper.Map<CreateFilmCommand>(createFilmDto);

            var filmId = await Mediator.Send(command);

            return Ok(filmId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateFilmDto updateFilmDto)
        {
            var command = _mapper.Map<UpdateFilmCommand>(updateFilmDto);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteFilmCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }

    }
}
