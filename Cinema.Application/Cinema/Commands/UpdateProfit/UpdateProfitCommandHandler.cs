using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Commands.UpdateProfit
{
    public class UpdateProfitCommandHandler
        : IRequestHandler<UpdateProfitCommand,Guid>
    {
        private readonly ICinemaDbContext _dbContext;
        public UpdateProfitCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(UpdateProfitCommand command,
                                       CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Profits.FirstOrDefaultAsync(profit =>
                profit.Id == command.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Profit), command.Id);

            var Film = await _dbContext.Films.Include(s => s.Tickets).FirstOrDefaultAsync(
                film => film.Id == command.FilmId, cancellationToken);

            int earn = 0;

            foreach (var Ticket in Film.Tickets)
            {
                earn += Ticket.TicketPrice;
            }

            entity.FilmId = command.FilmId;
            entity.Earnings = earn;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
