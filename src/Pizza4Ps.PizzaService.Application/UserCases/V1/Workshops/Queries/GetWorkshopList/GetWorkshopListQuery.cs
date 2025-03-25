using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Queries.GetWorkshopList
{
    public class GetWorkshopListQuery : PaginatedQuery<PaginatedResultDto<WorkshopDto>>
    {

    }
}
