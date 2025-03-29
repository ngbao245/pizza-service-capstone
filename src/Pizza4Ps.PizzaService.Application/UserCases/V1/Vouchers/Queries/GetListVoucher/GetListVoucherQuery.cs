using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetListVoucher
{
    public class GetListVoucherQuery : PaginatedQuery<PaginatedResultDto<VoucherDto>>
    {
        public Guid? VoucherBatchId { get; set; }
    }
}
