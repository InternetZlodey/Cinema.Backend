using MediatR;

namespace Cinema.Application.Cinema.Queries.GetTicket
{
    public class GetTicketQuery : IRequest<TicketDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
