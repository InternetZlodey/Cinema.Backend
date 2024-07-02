using AutoMapper;
using Cinema.Application.Cinema.Queries.GetFilm.ByName;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using MediatR;
using System.Globalization;

namespace Cinema.Application.Cinema.Queries.GetFilm.ByGenre
{
    public class GetFilmByGenreQueryHandler
        : IRequestHandler<GetFilmByGenreQuery, FilmList>
    {
        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFilmByGenreQueryHandler(ICinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FilmList> Handle(GetFilmByGenreQuery query,
                                           CancellationToken cancellation)
        {
            var entity = _mapper.Map < List<FilmDetailsVm> >(_dbContext.Films.AsEnumerable().Where(
                film => film.Genres.ToLower().Contains(
                    query.Genre.ToLower())
                )
                .ToList());

            if (entity.Count == 0)
                throw new NotFoundException(nameof(FilmList), "Фильмов с таким жанром нет");

            return new FilmList { Films = entity };
        }
    }
}
