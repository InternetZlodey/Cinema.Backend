using MediatR;

namespace Cinema.Application.Cinema.Queries.GetSeats
{
    public class GetSeatListQuery : IRequest<SeatListVm>
    {
    }
}
