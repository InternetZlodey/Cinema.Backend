using AutoMapper;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Queries.GetTicket
{
    public class GetTicketQueryHandler
        : IRequestHandler<GetTicketQuery, TicketDetailsVm>
    {
        private readonly ICinemaDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetTicketQueryHandler(ICinemaDbContext dbcontext, IMapper mapper)
            => (_dbcontext,_mapper) = (dbcontext,mapper);

        public async Task<TicketDetailsVm> Handle(GetTicketQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Tickets
                .Include(f => f.Film).Include(s => s.Seat)
                .FirstOrDefaultAsync(Ticket => Ticket.Id == request.Id, cancellationToken);
            
            //Получаем Холл в котором данное место
            entity.Seat.Hall = await _dbcontext.Halls.FirstOrDefaultAsync(p => p.Id == entity.Seat.HallID);
            
            var ticket = new TicketDetailsVm
            {
                Id = entity.Id,
                TicketPrice = entity.TicketPrice,
                SessionDate = entity.SessionDate,
                Film = _mapper.Map<FilmDto>(entity.Film),
                Seat = _mapper.Map<SeatDto>(entity.Seat)
            };

            if (entity == null)
                throw new NotFoundException(nameof(Ticket), request.Id);

            return _mapper.Map<TicketDetailsVm>(entity);
        }
    }
}
