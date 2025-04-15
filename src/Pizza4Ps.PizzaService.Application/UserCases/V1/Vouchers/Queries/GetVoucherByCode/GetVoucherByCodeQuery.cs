using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetVoucherByCode
{
    public class GetVoucherByCodeQuery : PaginatedQuery<VoucherDto>
    {
        public string Code { get; set; } = string.Empty;
    }
}
