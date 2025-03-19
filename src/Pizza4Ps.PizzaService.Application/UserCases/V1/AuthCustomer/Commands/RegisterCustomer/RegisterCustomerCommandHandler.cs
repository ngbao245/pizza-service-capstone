using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand>
    {
        private readonly IAppUserCustomerService _appUserCustomerService;

        public RegisterCustomerCommandHandler(IAppUserCustomerService appUserCustomerService)
        {
            _appUserCustomerService = appUserCustomerService;
        }
        public async Task Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            await _appUserCustomerService.Register(
                username: request.UserName,
                password: request.Password,
                fullName: request.FullName,
                phone: request.Phone,
                address: request.Address,
                gender: request.Gender,
                dateOfBirth: request.DateOfBirth,
                email: request.Email);
        }
    }
}
