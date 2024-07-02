using MediatR;

namespace Cinema.Application.Cinema.Commands.CreateProfit
{
    public class CreateProfitCommand : IRequest<Guid>
    {
        public Guid FilmId { get; set; }
    }
}
