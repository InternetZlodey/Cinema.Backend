using AutoMapper;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Queries.GetFilm
{
    internal class GetFilmDetailsQueryHandler
        : IRequestHandler<GetFilmDetailsQuery, FilmDetailsVm>
    {
        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFilmDetailsQueryHandler(ICinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FilmDetailsVm> Handle(GetFilmDetailsQuery request,
                                            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Films.FirstOrDefaultAsync(
                film => film.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Film),request.Id);

            return _mapper.Map<FilmDetailsVm>(entity);
        }
    }
}
