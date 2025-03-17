using Microsoft.AspNetCore.Identity;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Helpers;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class AppUserCustomerService : DomainService, IAppUserCustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppUserCustomerRepository _appUserCustomerRepository;
        private readonly ICustomerRepository _customerRepository;

        public AppUserCustomerService(IUnitOfWork unitOfWork,
            IAppUserCustomerRepository appUserCustomerRepositorytory, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _appUserCustomerRepository = appUserCustomerRepositorytory;
            _customerRepository = customerRepository;
        }
        public Task ChangePassword(string appUserCustomerId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task Register(string username, string password, string? fullName, string? phone, string? address, bool? gender, DateTime? dateOfBirth, string? email)
        {
            var existedAppUserCustomer = await _appUserCustomerRepository.GetSingleAsync(x => x.UserName == username);
            if (existedAppUserCustomer != null)
            {
                throw new BusinessException("Username is existed, please try again");
            }
            PasswordHelperCustomer.CreatePasswordHash(password, out string passwordHash, out string salt);
            var newAppUserCustomer = new AppUserCustomer(userName: username, passwordHash: passwordHash, salt: salt);
            var CustomerInfo = await _customerRepository.GetSingleAsync(x => x.Phone == phone);
            if (CustomerInfo != null)
            {
                if (CustomerInfo.AppUserCustomerId != null)
                {
                    throw new BusinessException("Phone number has been registered");
                }
                CustomerInfo.SetAppUserCustomerId(newAppUserCustomer.Id);
                _customerRepository.Update(CustomerInfo);
            }
            else
            {
                CustomerInfo = new Customer(
                    fullName: fullName,
                    phone: phone,
                    address: address,
                    gender: gender,
                    dateOfBirth: dateOfBirth,
                    email: email, 
                    appUserCustomerId: newAppUserCustomer.Id);
                _customerRepository.Add(CustomerInfo);
            }
            _appUserCustomerRepository.Add(newAppUserCustomer);  
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
