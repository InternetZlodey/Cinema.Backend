using MediatR;

namespace Cinema.Application.Cinema.Queries.GetHall
{
    public class GetHallDetailsQuery : IRequest<HallDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
