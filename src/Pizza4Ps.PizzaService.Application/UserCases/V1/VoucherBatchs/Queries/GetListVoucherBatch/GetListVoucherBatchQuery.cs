using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherBatchs.Queries.GetListVoucherBatch
{
    public class GetListVoucherBatchQuery : PaginatedQuery<PaginatedResultDto<VoucherBatchDto>>
    {
    }
}
