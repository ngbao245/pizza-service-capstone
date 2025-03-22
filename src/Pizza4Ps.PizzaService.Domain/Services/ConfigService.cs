using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

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

        public async Task<Guid> UpdateAsync(Guid id, ConfigType configType, string key, string value)
        {
            var entity = await _configRepository.GetSingleByIdAsync(id);
            entity.UpdateConfig(configType, key, value);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
