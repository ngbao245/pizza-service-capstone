using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class AdditionalFeeService : DomainService, IAdditionalFeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdditionalFeeRepository _additionalFeeRepository;

        public AdditionalFeeService(IUnitOfWork unitOfWork, IAdditionalFeeRepository additionalFeeRepository)
        {
            _unitOfWork = unitOfWork;
            _additionalFeeRepository = additionalFeeRepository;
        }

        public async Task<Guid> CreateAsync(string name, string description, decimal value)
        {
            var entity = new AdditionalFee(Guid.NewGuid(), name, description, value);
            _additionalFeeRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
