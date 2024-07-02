using MediatR;

namespace Cinema.Application.Cinema.Queries.GetSeat
{
    public class GetSeatDetailsQuery : IRequest<SeatDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
