using Pizza4Ps.PizzaService.Application.Contract.Abstractions.Services.IExternalServiceBase;
using Pizza4Ps.PizzaService.Application.Contract.DTOs;

namespace Pizza4Ps.PizzaService.Application.Contract.Abstractions.Services
{
    public interface IStaffService : IExternalService
    {
        Task<List<StaffDto>> GetListAsync();
    }
}
