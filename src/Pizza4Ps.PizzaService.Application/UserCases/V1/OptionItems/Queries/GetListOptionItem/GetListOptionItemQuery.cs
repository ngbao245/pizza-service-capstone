using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItem
{
    public class GetListOptionItemQuery : PaginatedQuery<PaginatedResultDto<OptionItemDto>>
    {
        public string? Name { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public Guid? OptionId { get; set; }
    }
}
