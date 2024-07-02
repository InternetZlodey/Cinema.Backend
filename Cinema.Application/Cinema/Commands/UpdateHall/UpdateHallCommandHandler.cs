using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Commands.UpdateHall
{
    public class UpdateHallCommandHandler
        : IRequestHandler<UpdateHallCommand,Guid>
    {
        private readonly ICinemaDbContext _dbContext;
        public UpdateHallCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(UpdateHallCommand command,
                                       CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Halls.FirstOrDefaultAsync(hall =>
                hall.Id == command.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Hall), command.Id);

            entity.Name = command.Name;
            entity.SeatsNumber = command.SeatsNumber;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
