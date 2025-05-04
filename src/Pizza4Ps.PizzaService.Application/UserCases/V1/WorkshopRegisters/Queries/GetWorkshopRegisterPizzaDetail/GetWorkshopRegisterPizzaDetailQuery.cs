using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterPizzaDetail
{
    public class GetWorkshopRegisterPizzaDetailQuery : IRequest<List<GetWorkshopRegisterPizzaDetailQueryResponse>>
    {
        public Guid WorkshopId { get; set; }
    }
}
