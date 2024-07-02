using MediatR;
namespace Cinema.Application.Cinema.Commands.CreateFilm
{
    public class CreateFilmCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearPublished { set; get; }
        public string Genres { get; set; }
        public string Duration { get; set; }
    }
}
