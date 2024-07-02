using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;

namespace Cinema.Application.Cinema.Commands.DeleteHall
{
    public class DeleteHallCommandHandler
        : IRequestHandler<DeleteHallCommand>
    {
        private readonly ICinemaDbContext _dbContext;
        public DeleteHallCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteHallCommand command,
                           CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Halls.FindAsync(
                new object[] { command.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Hall), command.Id);

            _dbContext.Halls.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
