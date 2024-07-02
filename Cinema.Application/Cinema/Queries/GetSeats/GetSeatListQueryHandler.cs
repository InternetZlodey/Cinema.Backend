using AutoMapper;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Queries.GetSeats
{
    public class GetSeatListQueryHandler
        : IRequestHandler<GetSeatListQuery, SeatListVm>
    {
        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSeatListQueryHandler(ICinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SeatListVm> Handle(GetSeatListQuery request,
                                            CancellationToken cancellationToken)
        {
            var seatQuery = await _dbContext.Seats.ToListAsync(cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            if (seatQuery == null)
                throw new NotFoundException(nameof(Seat), "Ошибка");

            return new SeatListVm { Seats = _mapper.Map<List<SeatLookupDto>>(seatQuery) };
        }
    }
}
