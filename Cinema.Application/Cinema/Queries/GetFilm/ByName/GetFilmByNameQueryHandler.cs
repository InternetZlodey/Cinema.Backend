using AutoMapper;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;

namespace Cinema.Application.Cinema.Queries.GetFilm.ByName
{
    public class GetFilmByNameQueryHandler
        : IRequestHandler<GetFilmByNameQuery, FilmList>
    {
        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFilmByNameQueryHandler(ICinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FilmList> Handle(GetFilmByNameQuery request,
                                           CancellationToken cancellationToken)
        {
            var entity = _mapper.Map < List<FilmDetailsVm> >
                (
                  _dbContext.Films.AsEnumerable().Where(
                                                        m => m.Name.ToLower()
                                                        .Contains(request.Name.ToLower())
                                                       )
                                                        .ToList()
                );

            if (entity.Count == 0)
                throw new NotFoundException(nameof(Film), "Такого фильма нет");

            return new FilmList { Films = entity };
        }
    }
}
