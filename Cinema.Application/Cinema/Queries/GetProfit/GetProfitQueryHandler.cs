using AutoMapper;
using Cinema.Application.Cinema.Queries.GetProfits;
using Cinema.Application.Common.Exceptions;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Cinema.Queries.GetProfit
{
    public class GetProfitQueryHandler 
        : IRequestHandler<GetProfitQuery,ProfitDetailsVm>
    {
        private readonly ICinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProfitQueryHandler(ICinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProfitDetailsVm> Handle(GetProfitQuery request,
                                            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Profits.Include(s => s.Film).FirstOrDefaultAsync(
                profit => profit.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Profit), request.Id);

            return _mapper.Map<ProfitDetailsVm>(entity);
        }
    }
}
