using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AdditionalFees.Queries.GetListAdditionalFee
{
    public class GetListAdditionalFeeQuery : PaginatedQuery<PaginatedResultDto<AdditionalFeeDto>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Value { get; set; }
        public Guid? OrderId { get; set; }
    }
}

