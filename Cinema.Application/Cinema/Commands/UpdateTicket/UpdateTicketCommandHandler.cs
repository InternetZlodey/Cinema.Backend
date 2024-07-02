using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Commands.UpdateTicket
{
    public class UpdateTicketCommandHandler
        : IRequestHandler<UpdateTicketCommand, Guid>
    {
        private readonly ICinemaDbContext _dbContext;

        public UpdateTicketCommandHandler(ICinemaDbContext dbcontext) => _dbContext = dbcontext;

        public async Task<Guid> Handle(UpdateTicketCommand command,
                            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Tickets.FirstOrDefaultAsync(ticket =>
                ticket.Id == command.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Ticket), command.Id);

            entity.TicketPrice = command.TicketPrice;
            entity.SessionDate = command.SessionDate;
            entity.FilmId = command.FilmId;
            entity.SeatId = command.SeatId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
