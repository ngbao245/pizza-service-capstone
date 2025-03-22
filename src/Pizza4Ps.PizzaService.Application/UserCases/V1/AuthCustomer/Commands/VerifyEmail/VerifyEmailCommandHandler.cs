using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.VerifyEmail
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public VerifyEmailCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }
        public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetSingleByIdAsync(request.CustomerId!.Value);
            if (customer == null)
            {
                throw new BusinessException("Customer is not found");
            }
            if (customer.VerifiedCodeEmail != request.Code)
            {
                throw new BusinessException("Code is not correct");
            }
            customer.SetIsVerifiedEmail();
            _customerRepository.Update(customer);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
