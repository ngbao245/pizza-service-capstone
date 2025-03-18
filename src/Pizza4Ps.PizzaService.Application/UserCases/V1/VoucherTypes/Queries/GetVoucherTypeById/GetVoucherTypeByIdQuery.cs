using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherTypes.Queries.GetVoucherTypeById
{
    public class GetVoucherTypeByIdQuery : IRequest<VoucherTypeDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
