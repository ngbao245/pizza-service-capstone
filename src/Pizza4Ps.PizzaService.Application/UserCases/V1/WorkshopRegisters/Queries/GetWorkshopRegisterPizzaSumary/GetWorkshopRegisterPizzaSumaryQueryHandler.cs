using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterPizzaSumary
{
    public class GetWorkshopRegisterPizzaSumaryQueryHandler : IRequestHandler<GetWorkshopRegisterPizzaSumaryQuery, List<GetWorkshopRegisterPizzaSumaryQueryResponse>>
    {
        private readonly IWorkshopPizzaRegisterRepository _workshopPizzaRegisterRepository;

        public GetWorkshopRegisterPizzaSumaryQueryHandler(IWorkshopPizzaRegisterRepository workshopPizzaRegisterRepository)
        {
            _workshopPizzaRegisterRepository = workshopPizzaRegisterRepository;
        }
        public async Task<List<GetWorkshopRegisterPizzaSumaryQueryResponse>> Handle(GetWorkshopRegisterPizzaSumaryQuery request, CancellationToken cancellationToken)
        {
            var summary = await _workshopPizzaRegisterRepository
                .GetListAsNoTracking(wpr => wpr.WorkshopRegister.WorkshopId == request.WorkshopId
                && wpr.WorkshopRegister.WorkshopRegisterStatus != Domain.Enums.WorkshopRegisterStatus.Cancelled)
                .GroupBy(wpr => wpr.ProductId)
                .Select(g => new GetWorkshopRegisterPizzaSumaryQueryResponse
                {
                    ProductId = g.Key,
                    ProductName = g.First().Product.Name,
                    TotalQuantity = g.Count(),
                })
                .ToListAsync();
            return summary;
        }
    }
}
