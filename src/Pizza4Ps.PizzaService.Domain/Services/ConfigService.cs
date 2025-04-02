using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Constants;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ConfigService : DomainService, IConfigService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfigRepository _configRepository;

        public ConfigService(IUnitOfWork unitOfWork, IConfigRepository configRepository)
        {
            _unitOfWork = unitOfWork;
            _configRepository = configRepository;
        }

        public async Task<Guid> UpdateValueAsync(Guid id, string value)
        {
            var entity = await _configRepository.GetSingleByIdAsync(id);
            if (entity == null) throw new BusinessException(BussinessErrorConstants.ConfigErrorConstant.CONFIG_NOT_FOUND);
            entity.UpdateValue(value);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
