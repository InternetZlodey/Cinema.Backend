using Cinema.Application.Cinema.Queries.GetProfits;
using MediatR;

namespace Cinema.Application.Cinema.Queries.GetProfit
{
    public class GetProfitQuery : IRequest<ProfitDetailsVm>
    {
        public Guid Id { get; set; }    
    }
}
