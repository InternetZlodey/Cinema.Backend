using Cinema.Domain;
using MediatR;

namespace Cinema.Application.Cinema.Commands.UpdateTicket
{
    public class UpdateTicketCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public int TicketPrice { get; set; }

        public DateTime SessionDate { get; set; }

        //Много на много с Films
        public Guid FilmId { get; set; }

        //Один к одному с Seats
        public Guid SeatId { get; set; }
    }
}
