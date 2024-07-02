using Cinema.Application.Cinema.Queries.GetFilm.ByName;
using MediatR;

namespace Cinema.Application.Cinema.Queries.GetFilm.ByGenre
{
    public class GetFilmByGenreQuery : IRequest<FilmList>
    {
        public string Genre { get; set; }
    }
}
