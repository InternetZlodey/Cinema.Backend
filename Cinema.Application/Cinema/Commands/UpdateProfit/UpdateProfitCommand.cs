using MediatR;

namespace Cinema.Application.Cinema.Commands.UpdateProfit
{
    public class UpdateProfitCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid FilmId { get; set; }
    }
}
