using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Commands.CreateSeat
{
    public class CreateSeatCommandHandler
        : IRequestHandler<CreateSeatCommand, Guid>
    {
        private readonly ICinemaDbContext _dbContext;
        public CreateSeatCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateSeatCommand request,
                                       CancellationToken cancellationToken)
        {
            var hall = await _dbContext.Halls.FindAsync(request.HallID);

            var seat = new Seat
            {
                Id = Guid.NewGuid(),
                Row = request.Row,
                SeatNumber = request.SeatNumber,
                HallID = request.HallID
            };

            if (seat == null)
                throw new NotFoundException(nameof(Seat), "Не удалось создать новое место");

            await _dbContext.Seats.AddAsync(seat);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return seat.Id;
        }
    }
}
