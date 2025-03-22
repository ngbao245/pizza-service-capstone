using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Roles.Queries.GetListRole
{
    public class GetListRoleQuery : PaginatedQuery<PaginatedResultDto<RoleDto>>
    {
        public string? Name { get; set; }
    }
}

