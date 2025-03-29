using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherBatchs.Queries.GetVoucherBatchById
{
    public class GetVoucherBatchByIdQuery : IRequest<VoucherBatchDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
