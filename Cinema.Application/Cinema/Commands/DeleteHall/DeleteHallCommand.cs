using MediatR;

namespace Cinema.Application.Cinema.Commands.DeleteHall
{
    public class DeleteHallCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
