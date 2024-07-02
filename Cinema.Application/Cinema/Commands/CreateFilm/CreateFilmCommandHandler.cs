using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;

namespace Cinema.Application.Cinema.Commands.CreateFilm
{
    public class CreateFilmCommandHandler
        : IRequestHandler<CreateFilmCommand, Guid>
    {
        private readonly ICinemaDbContext _dbContext;
        public CreateFilmCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateFilmCommand request,
                                       CancellationToken cancellationToken)
        {
            var film = new Film()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Country = request.Country,
                YearPublished = request.YearPublished,
                Genres = request.Genres,
                Duration = request.Duration
            };

            await _dbContext.Films.AddAsync(film);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return film.Id;
        }
    }
}
