using MediatR;
using Pizza4Ps.PizzaService.Application.Helpers;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.SendCodeVerifyPhone
{
    public class SendOtpVerifyPhoneCommandHandler : IRequestHandler<SendOtpVerifyPhoneCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TwilioSmsService _twilioSmsService;
        private readonly ICustomerRepository _customerRepository;

        public SendOtpVerifyPhoneCommandHandler(TwilioSmsService twilioSmsService,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
             
        {
            _unitOfWork = unitOfWork;
            _twilioSmsService = twilioSmsService;
            _customerRepository = customerRepository;
        }
        public async Task Handle(SendOtpVerifyPhoneCommand request, CancellationToken cancellationToken)
        {
            var code = RegistrationCodeGenerator.GenerateCode(6);
            await _twilioSmsService.SendOtpAsync(request.PhoneNumber, code);
            var customer = await _customerRepository.GetSingleAsync(x => x.Phone == request.PhoneNumber);
            if (customer == null)
            {
                customer = new Customer(request.PhoneNumber);
                _customerRepository.Add(customer);
            }
            else
            {
                _customerRepository.Update(customer);
            }
            customer.SetVerifiedCodePhone(code);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
