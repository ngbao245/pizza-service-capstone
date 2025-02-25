using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.PayOrderCash
{
    public class PayOrderCashCommand : IRequest<ResultDto<Guid>>
    {
        public Guid OrderId { get; set; }
    }
}
