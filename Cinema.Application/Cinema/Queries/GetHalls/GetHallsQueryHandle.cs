using AutoMapper;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Queries.GetHalls
{
    public class GetHallsQueryHandle
        : IRequestHandler<GetHallsQuery, HallListDetailsVm>
    {
        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetHallsQueryHandle(ICinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<HallListDetailsVm> Handle(GetHallsQuery request,
                                            CancellationToken cancellationToken)
        {
            var hallQuery = await _dbContext.Halls.Include(a => a.Seats).ToListAsync(cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            if (hallQuery == null)
                throw new NotFoundException(nameof(Hall), "");

            return new HallListDetailsVm { Halls = _mapper.Map<List<HallLookupDto>>(hallQuery) };
        }
    }
}
