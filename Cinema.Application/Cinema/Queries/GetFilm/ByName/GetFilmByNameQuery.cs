using MediatR;

namespace Cinema.Application.Cinema.Queries.GetFilm.ByName
{
    public class GetFilmByNameQuery : IRequest<FilmList>
    {
        public string Name { get; set; }
    }
}
