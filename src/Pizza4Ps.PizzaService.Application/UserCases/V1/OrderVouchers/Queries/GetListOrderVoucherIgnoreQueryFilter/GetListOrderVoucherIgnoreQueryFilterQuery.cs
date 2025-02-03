using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetListOrderVoucherIgnoreQueryFilter
{
    public class GetListOrderVoucherIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<OrderVoucherDto>>
	{
        public bool IsDeleted { get; set; } = false;
        public Guid? OrderId { get; set; }
        public Guid? VoucherId { get; set; }
    }
}
