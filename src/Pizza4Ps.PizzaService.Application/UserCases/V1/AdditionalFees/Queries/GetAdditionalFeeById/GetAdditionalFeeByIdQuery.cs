using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AdditionalFees.Queries.GetAdditionalFeeById
{
    public class GetAdditionalFeeByIdQuery : IRequest<AdditionalFeeDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}

