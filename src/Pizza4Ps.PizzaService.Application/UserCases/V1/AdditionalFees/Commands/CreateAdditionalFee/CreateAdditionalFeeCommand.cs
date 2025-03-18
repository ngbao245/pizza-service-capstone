using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AdditionalFees.Commands.CreateAdditionalFee
{
    public class CreateAdditionalFeeCommand : IRequest<ResultDto<Guid>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
    }
}