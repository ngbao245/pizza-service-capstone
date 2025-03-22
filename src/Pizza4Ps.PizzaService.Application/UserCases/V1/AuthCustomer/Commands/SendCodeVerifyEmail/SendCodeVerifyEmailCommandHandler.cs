using MediatR;
using Pizza4Ps.PizzaService.Application.Helpers;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.SendCodeVerifyEmail
{
    public class SendCodeVerifyEmailCommandHandler : IRequestHandler<SendCodeVerifyEmailCommand>
    {
        private readonly EmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public SendCodeVerifyEmailCommandHandler(ICustomerRepository customerRepository, 
            IUnitOfWork unitOfWork, EmailService emailService)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }
        public async Task Handle(SendCodeVerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetSingleByIdAsync(request.CustomerId!.Value);
            if (customer == null)
            {
                throw new BusinessException("Customer is not found");
            }
            var code = RegistrationCodeGenerator.GenerateCode(6);
            await _emailService.SendVerifiedCodeEmail(customer.Email!, customer.FullName!, code);
            customer.SetVerifiedCodeEmail(code);
            _customerRepository.Update(customer);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
