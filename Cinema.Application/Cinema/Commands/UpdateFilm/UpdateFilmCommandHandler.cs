using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Commands.UpdateFilm
{
    public class UpdateFilmCommandHandler
        : IRequestHandler<UpdateFilmCommand, Guid>
    {
        private readonly ICinemaDbContext _dbContext;
        public UpdateFilmCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(UpdateFilmCommand request,
                                       CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Films.FirstOrDefaultAsync(film =>
                film.Id == request.Id, cancellationToken);

            if(entity == null) 
                throw new NotFoundException(nameof(Film), request.Id);

            entity.Name = request.Name;
            entity.Duration = request.Duration;
            entity.YearPublished = request.YearPublished;
            entity.Country = request.Country;
            entity.Genres = request.Genres;
            entity.Duration = request.Duration;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
