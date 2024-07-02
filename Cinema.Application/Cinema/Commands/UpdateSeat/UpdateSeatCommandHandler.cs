using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Commands.UpdateSeat
{
    public class UpdateSeatCommandHandler
        : IRequestHandler<UpdateSeatCommand, Guid>
    {
        private readonly ICinemaDbContext _dbContext;
        public UpdateSeatCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(UpdateSeatCommand command,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Seats.FirstOrDefaultAsync(film =>
                film.Id == command.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Hall), command.Id);

            entity.Row = command.Row;
            entity.SeatNumber = command.SeatNumber;
            entity.HallID = command.HallID;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
