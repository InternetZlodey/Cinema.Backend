using AutoMapper;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Queries.GetHall
{
    public class GetHallDetailsQueryHandler
        : IRequestHandler<GetHallDetailsQuery, HallDetailsVm>
    {

        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetHallDetailsQueryHandler(ICinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<HallDetailsVm> Handle(GetHallDetailsQuery request,
                                            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Halls.Include(s => s.Seats).FirstOrDefaultAsync(
                hall => hall.Id == request.Id, cancellationToken);

            if(entity == null)
                throw new NotFoundException(nameof(Hall), request.Id);

            return _mapper.Map<HallDetailsVm>(entity);
        }
    }
}
