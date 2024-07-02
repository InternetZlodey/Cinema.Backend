using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;

namespace Cinema.Application.Cinema.Commands.DeleteProfit
{
    public class DeleteProfitCommandHandler
        : IRequestHandler<DeleteProfitCommand>
    {
        private readonly ICinemaDbContext _dbContext;

        public DeleteProfitCommandHandler(ICinemaDbContext dbcontext) => _dbContext = dbcontext;

        public async Task Handle(DeleteProfitCommand command,
                                CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Profits.FindAsync(
                new object[] { command.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Profit), command.Id);

            _dbContext.Profits.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
