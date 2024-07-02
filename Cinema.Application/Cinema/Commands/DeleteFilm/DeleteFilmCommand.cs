using MediatR;


namespace Cinema.Application.Cinema.Commands.DeleteFilm
{
    public class DeleteFilmCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
