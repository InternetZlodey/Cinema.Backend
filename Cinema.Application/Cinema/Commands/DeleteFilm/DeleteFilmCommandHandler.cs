using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;

namespace Cinema.Application.Cinema.Commands.DeleteFilm
{
    public class DeleteFilmCommandHandler 
        : IRequestHandler<DeleteFilmCommand>
    {
        private readonly ICinemaDbContext _dbContext;
        public DeleteFilmCommandHandler(ICinemaDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteFilmCommand request, 
                                CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Films.FindAsync(
                new object[] { request.Id }, cancellationToken);
            
            if (entity == null)
                throw new NotFoundException(nameof(Film), request.Id);

            _dbContext.Films.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
