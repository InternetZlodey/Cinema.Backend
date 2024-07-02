using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;

namespace Cinema.Application.Cinema.Commands.CreateHall
{
    public class CreateHallCommandHandler
        : IRequestHandler<CreateHallCommand, Guid>
    {
        private readonly ICinemaDbContext _dbContext;
        public CreateHallCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateHallCommand request,
                                       CancellationToken cancellationToken)
        {
            var hall = new Hall()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                SeatsNumber = request.SeatsNumber
            };

            await _dbContext.Halls.AddAsync(hall);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return hall.Id;
        }
    }
}
