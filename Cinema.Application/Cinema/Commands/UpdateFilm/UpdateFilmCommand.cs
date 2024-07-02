using MediatR;

namespace Cinema.Application.Cinema.Commands.UpdateFilm
{
    public class UpdateFilmCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearPublished { set; get; }
        public string Genres { get; set; }
        public string Duration { get; set; }
    }
}
