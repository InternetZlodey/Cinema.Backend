using AutoMapper;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Queries.GetSeat
{
    public class GetSeatDetailsQueryHandler
        : IRequestHandler<GetSeatDetailsQuery, SeatDetailsVm>
    {
        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSeatDetailsQueryHandler(ICinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SeatDetailsVm> Handle(GetSeatDetailsQuery request,
                                            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Seats.Include(h => h.Hall).FirstOrDefaultAsync(
                seat => seat.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Seat), request.Id);

            return _mapper.Map<SeatDetailsVm>(entity);
        }
    }
}
