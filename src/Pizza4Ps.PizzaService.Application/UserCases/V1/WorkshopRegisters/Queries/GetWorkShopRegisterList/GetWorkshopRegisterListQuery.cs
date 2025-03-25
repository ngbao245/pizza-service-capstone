using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkShopRegisterList
{
    public class GetWorkshopRegisterListQuery : PaginatedQuery<PaginatedResultDto<WorkshopRegisterDto>>
    {
        public Guid? CustomerId { get; set; }
        public Guid? WorkshopId { get; set; }
    }
}
