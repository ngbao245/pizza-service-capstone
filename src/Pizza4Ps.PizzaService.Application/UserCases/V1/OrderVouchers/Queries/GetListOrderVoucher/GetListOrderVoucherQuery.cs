using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetListOrderVoucher
{
    public class GetListOrderVoucherQuery : PaginatedQuery<PaginatedResultDto<OrderVoucherDto>>
    {
        public Guid? OrderId { get; set; }
        public Guid? VoucherId { get; set; }
    }
}
