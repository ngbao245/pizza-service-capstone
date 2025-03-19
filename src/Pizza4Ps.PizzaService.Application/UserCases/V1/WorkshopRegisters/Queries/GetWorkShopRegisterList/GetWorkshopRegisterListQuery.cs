using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkShopRegisterList
{
    public class GetWorkshopRegisterListQuery : PaginatedQuery<PaginatedResultDto<WorkshopRegisterDto>>
    {

    }
}
