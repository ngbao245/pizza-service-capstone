using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterPizzaSumary
{
    public class GetWorkshopRegisterPizzaSumaryQuery : IRequest<List<GetWorkshopRegisterPizzaSumaryQueryResponse>>
    {
        public Guid WorkshopId { get; set; }
    }
}
