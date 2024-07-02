using MediatR;

namespace Cinema.Application.Cinema.Commands.DeleteProfit
{
    public class DeleteProfitCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
