using MediatR;

namespace Cinema.Application.Cinema.Queries.GetFilm
{
    public class GetFilmDetailsQuery : IRequest<FilmDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
