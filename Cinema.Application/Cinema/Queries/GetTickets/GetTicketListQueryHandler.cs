using AutoMapper;
using Cinema.Application.Cinema.Queries.GetSeats;
using Cinema.Application.Cinema.Queries.GetTicket;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Queries.GetTickets
{
    public class GetTicketListQueryHandler
        : IRequestHandler<GetTicketListQuery, TicketLookupDto>
    {
        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTicketListQueryHandler(ICinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TicketLookupDto> Handle(GetTicketListQuery request,
            CancellationToken cancellationToken)
        {
            var ticketQuery = await _dbContext.Tickets
                .Include(f => f.Film).Include(s => s.Seat).ToListAsync();
            
            foreach (var ticket in ticketQuery)
                ticket.Seat.Hall = await _dbContext.Halls.FirstOrDefaultAsync
                    (p => p.Id == ticket.Seat.HallID);

            await _dbContext.SaveChangesAsync(cancellationToken);

            if (ticketQuery == null)
                throw new NotFoundException(nameof(Seat), "Ошибка");

            return new TicketLookupDto { Tickets = _mapper.Map<List<TicketDetailsVm>>(ticketQuery) };
        }
    }
}
