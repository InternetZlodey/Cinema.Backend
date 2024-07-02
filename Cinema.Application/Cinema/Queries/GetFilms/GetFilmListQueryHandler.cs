using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Queries.GetFilms
{
    public class GetFilmListQueryHandler
        : IRequestHandler<GetFilmListQuery, FilmListVm>
    {
        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFilmListQueryHandler(ICinemaDbContext dbContext, IMapper mapper)
        { 
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FilmListVm> Handle(GetFilmListQuery request,
                                            CancellationToken cancellationToken)
        {
            var filmQuery = await _dbContext.Films.ToListAsync(cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            if (filmQuery == null)
                throw new NotFoundException(nameof(Film),"Ошибка");

            return new FilmListVm { Films = _mapper.Map<List<FilmLookupDto>>(filmQuery) };
        }
    }
}
