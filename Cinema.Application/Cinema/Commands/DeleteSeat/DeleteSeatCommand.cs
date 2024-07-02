using MediatR;

namespace Cinema.Application.Cinema.Commands.DeleteSeat
{
    public class DeleteSeatCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
