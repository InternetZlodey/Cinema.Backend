using MediatR;

namespace Cinema.Application.Cinema.Commands.UpdateSeat
{
    public class UpdateSeatCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int SeatNumber { get; set; }

        public Guid HallID { get; set; }
    }
}
