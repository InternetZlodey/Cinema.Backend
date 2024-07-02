using MediatR;

namespace Cinema.Application.Cinema.Commands.DeleteTicket
{
    public class DeleteTicketCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
