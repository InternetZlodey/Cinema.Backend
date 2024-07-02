using MediatR;

namespace Cinema.Application.Cinema.Commands.CreateSeat
{
    public class CreateSeatCommand : IRequest<Guid>
    {
        public int Row { get; set; }
        public int SeatNumber { get; set; }

        public Guid HallID { get; set; }
    }
}
