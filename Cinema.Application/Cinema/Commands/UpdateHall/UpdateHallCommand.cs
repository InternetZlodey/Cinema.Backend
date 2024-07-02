using MediatR;

namespace Cinema.Application.Cinema.Commands.UpdateHall
{
    public class UpdateHallCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SeatsNumber { get; set; }

    }
}
