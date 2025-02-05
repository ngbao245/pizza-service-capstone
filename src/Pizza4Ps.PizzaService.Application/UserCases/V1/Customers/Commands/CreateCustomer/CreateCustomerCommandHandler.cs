using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResultDto<Guid>>
    {
        private readonly ICustomerService _customerService;

        public CreateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerService.CreateAsync(
                request.FullName,
                request.Phone);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
