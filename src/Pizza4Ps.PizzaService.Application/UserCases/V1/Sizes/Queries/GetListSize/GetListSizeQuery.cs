using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Sizes.Queries.GetListSize
{
    public class GetListSizeQuery : PaginatedQuery<PaginatedResultDto<SizeDto>>
    {
        public string? Name { get; set; }
        public int? DiameterCm { get; set; }
        public string? Description { get; set; }
    }
}
