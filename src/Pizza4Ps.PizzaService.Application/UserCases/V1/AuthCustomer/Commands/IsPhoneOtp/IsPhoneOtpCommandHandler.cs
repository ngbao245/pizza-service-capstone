using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using static Pizza4Ps.PizzaService.Domain.Constants.BussinessErrorConstants;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.IsPhoneOtp
{
    public class IsPhoneOtpCommandHandler : IRequestHandler<IsPhoneOtpCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public IsPhoneOtpCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<bool> Handle(IsPhoneOtpCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetSingleAsync(x => x.Phone == request.PhoneNumber);
            if (customer == null)
            {
                throw new BusinessException(CustomerErrorConstant.CUSTOMER_NOT_FOUND);
            }
            if (customer.PhoneOtp == null)
            {
                throw new BusinessException("Khách hàng này chưa có OTP");
            }
            if (customer.PhoneOtp != request.Otp)
            {
                throw new BusinessException("Mã OTP sai, vui lòng thử lại");
            }
            return true;
        }
    }
}
