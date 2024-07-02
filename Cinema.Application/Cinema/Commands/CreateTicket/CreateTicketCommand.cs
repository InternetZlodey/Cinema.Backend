using MediatR;

namespace Cinema.Application.Cinema.Commands.CreateTicket
{
    public class CreateTicketCommand : IRequest<Guid>
    {
        public int TicketPrice { get; set; }

        public DateTime SessionDate { get; set; }

        public Guid FilmId { get; set; }

        public Guid SeatId { get; set; }
    }
}
