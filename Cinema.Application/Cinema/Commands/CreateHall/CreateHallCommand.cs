using MediatR;

namespace Cinema.Application.Cinema.Commands.CreateHall
{
    public class CreateHallCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public int SeatsNumber { get; set; }
    }
}
