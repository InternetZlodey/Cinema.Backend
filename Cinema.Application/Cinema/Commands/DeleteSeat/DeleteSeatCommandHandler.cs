using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;

namespace Cinema.Application.Cinema.Commands.DeleteSeat
{
    public class DeleteSeatCommandHandler
        : IRequestHandler<DeleteSeatCommand>
    {
        private readonly ICinemaDbContext _dbContext;

        public DeleteSeatCommandHandler(ICinemaDbContext dbcontext) => _dbContext = dbcontext;

        public async Task Handle(DeleteSeatCommand command,
                                CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Seats.FindAsync(
                new object[] { command.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Seat), command.Id);

            _dbContext.Seats.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
