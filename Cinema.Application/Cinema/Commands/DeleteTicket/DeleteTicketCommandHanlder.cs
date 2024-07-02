using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Commands.DeleteTicket
{
    public class DeleteTicketCommandHanlder
        : IRequestHandler<DeleteTicketCommand>
    {
        private readonly ICinemaDbContext _dbContext;

        public DeleteTicketCommandHanlder(ICinemaDbContext dbcontext) => _dbContext = dbcontext;

        public async Task Handle(DeleteTicketCommand command,
                                 CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tickets.FindAsync(
                new object[] { command.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Ticket), command.Id);

            //Обновляем доход от фильма
            var profit = await _dbContext.Profits.FirstOrDefaultAsync(s => s.FilmId == entity.FilmId);

            if (profit != null)
                profit.Earnings -= entity.TicketPrice;

            _dbContext.Tickets.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
