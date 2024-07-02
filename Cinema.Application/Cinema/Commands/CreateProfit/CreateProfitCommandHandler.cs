using Cinema.Application.Cinema.Commands.CreateHall;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Cinema.Application.Cinema.Commands.CreateProfit
{
    public class CreateProfitCommandHandler 
        : IRequestHandler<CreateProfitCommand, Guid>
    {
        private readonly ICinemaDbContext _dbContext;
        public CreateProfitCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateProfitCommand request,
                                       CancellationToken cancellationToken)
        {
            var Film = await _dbContext.Films.Include(s => s.Tickets).FirstOrDefaultAsync(
                film => film.Id == request.FilmId, cancellationToken);

            int earn = 0;

            foreach (var Ticket in Film.Tickets)
            {
                earn += Ticket.TicketPrice;
            }

            var profit = new Profit()
            {
                Id = Guid.NewGuid(),
                FilmId = request.FilmId,
                Earnings = earn,
            };

            await _dbContext.Profits.AddAsync(profit);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return profit.Id;
        }
    }
}
