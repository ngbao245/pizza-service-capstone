using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IAppUserCustomerService : IDomainService
    {
        Task Register(string username, string password, string? fullName, string? phone, string? address, bool? gender, DateTime? dateOfBirth, string? email);

        Task ChangePassword(string appUserCustomerId, string oldPassword, string newPassword);
    }
}
