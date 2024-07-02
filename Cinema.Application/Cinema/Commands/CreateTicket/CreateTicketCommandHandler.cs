using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Application.Cinema.Commands.CreateTicket
{
    public class CreateTicketCommandHandler
        : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly ICinemaDbContext _dbContext;
        public CreateTicketCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateTicketCommand command,
            CancellationToken cancellationToken) 
        {
            var Ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                TicketPrice = command.TicketPrice,
                SessionDate = command.SessionDate,
                FilmId = command.FilmId,
                SeatId = command.SeatId
            };

            //Обновляем доход от фильма
            var profit = await _dbContext.Profits.FirstOrDefaultAsync(s => s.FilmId == command.FilmId);

            if (profit == null)
            {
                var p = new Profit
                {
                    Id = Guid.NewGuid(),
                    Earnings = command.TicketPrice,
                    FilmId = command.FilmId
                };

                await _dbContext.Profits.AddAsync(p);
            }
            else
            {
                profit.Earnings += Ticket.TicketPrice;
            }

            await _dbContext.Tickets.AddAsync(Ticket);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ticket.Id;

        }
    }
}
