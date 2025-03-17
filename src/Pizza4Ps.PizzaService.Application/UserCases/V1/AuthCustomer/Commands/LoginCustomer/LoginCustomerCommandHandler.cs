using MediatR;
using Microsoft.Extensions.Configuration;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Helpers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.LoginCustomer
{
    public class LoginCustomerCommandHandler : IRequestHandler<LoginCustomerCommand, LoginCustomerCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IAppUserCustomerRepository _appUserCustomerRepository;

        public LoginCustomerCommandHandler(IAppUserCustomerRepository appUserCustomerRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _appUserCustomerRepository = appUserCustomerRepository;
        }
        public async Task<LoginCustomerCommandResponse> Handle(LoginCustomerCommand request, CancellationToken cancellationToken)
        {
            var appUserCustomer = await _appUserCustomerRepository.GetSingleAsync(x => x.UserName == request.Username, "Customer");
            if (appUserCustomer == null)
            {
                throw new BusinessException("Username is not existed, please try again");
            }
            if (!PasswordHelperCustomer.VerifyPassword(request.Password, appUserCustomer.PasswordHash, appUserCustomer.Salt))
                throw new Exception("Password is invalid, please try again");
            DateTime expiredTime = DateTime.Now.AddDays(2);
            var result = new LoginCustomerCommandResponse
            {
                Token = JwtCustomerHelper.GenerateJwtCustomerToken(_configuration, appUserCustomer, expiredTime),
                Expiration = expiredTime,
            };
            return result;
        }
    }
}
