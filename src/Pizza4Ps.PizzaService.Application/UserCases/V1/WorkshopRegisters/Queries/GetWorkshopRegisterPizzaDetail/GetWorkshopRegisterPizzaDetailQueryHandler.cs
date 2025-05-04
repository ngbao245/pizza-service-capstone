using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterPizzaDetail
{
    public class GetWorkshopRegisterPizzaDetailQueryHandler : IRequestHandler<GetWorkshopRegisterPizzaDetailQuery, List<GetWorkshopRegisterPizzaDetailQueryResponse>>
    {
        private readonly IWorkshopPizzaRegisterRepository _workshopPizzaRegisterRepository;

        public GetWorkshopRegisterPizzaDetailQueryHandler(IWorkshopPizzaRegisterRepository workshopPizzaRegisterRepository)
        {
            _workshopPizzaRegisterRepository = workshopPizzaRegisterRepository;
        }
        public async Task<List<GetWorkshopRegisterPizzaDetailQueryResponse>> Handle(GetWorkshopRegisterPizzaDetailQuery request, CancellationToken cancellationToken)
        {
            var details = await _workshopPizzaRegisterRepository
                .GetListAsNoTracking(wpr => wpr.WorkshopRegister.WorkshopId == request.WorkshopId
                && wpr.WorkshopRegister.WorkshopRegisterStatus != Domain.Enums.WorkshopRegisterStatus.Cancelled)
                .Select(wpr => new GetWorkshopRegisterPizzaDetailQueryResponse
                {
                    CustomerName = wpr.WorkshopRegister.CustomerName,
                    CustomerPhone = wpr.WorkshopRegister.CustomerPhone,
                    ProductName = wpr.Name,
                })
                .ToListAsync();
            return details;
        }
    }
}
