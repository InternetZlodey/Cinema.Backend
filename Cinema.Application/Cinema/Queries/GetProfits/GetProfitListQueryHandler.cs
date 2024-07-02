using AutoMapper;
using Cinema.Application.Cinema.Queries.GetHalls;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Queries.GetProfits
{
    public class GetProfitListQueryHandler
        : IRequestHandler<GetProfitListQuery, ProfitLookupDto>
    {
        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProfitListQueryHandler(ICinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProfitLookupDto> Handle(GetProfitListQuery request,
            CancellationToken cancellationToken)
        {
            var profitQuery = await _dbContext.Profits
                .Include(a => a.Film)
                .ToListAsync(cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            if (profitQuery == null)
                throw new NotFoundException(nameof(Profit), "");

            return new ProfitLookupDto { Profits = _mapper.Map<List<ProfitDetailsVm>>(profitQuery) };
        }
    }
}
