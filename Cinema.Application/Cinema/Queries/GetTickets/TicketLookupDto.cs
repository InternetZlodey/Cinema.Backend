using Cinema.Application.Cinema.Queries.GetTicket;

namespace Cinema.Application.Cinema.Queries.GetTickets
{
    public class TicketLookupDto
    {
        public ICollection<TicketDetailsVm> Tickets { get; set; }
    }
}
