using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ConfigService : DomainService, IConfigService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfigRepository _configRepository;
        private readonly IJobManager _jobManager;

        public ConfigService(IUnitOfWork unitOfWork, IConfigRepository configRepository, IJobManager jobManager)
        {
            _unitOfWork = unitOfWork;
            _configRepository = configRepository;
            _jobManager = jobManager;
        }

        public async Task<Guid> UpdateValueAsync(Guid id, string value)
        {
            var entity = await _configRepository.GetSingleByIdAsync(id);
            if (entity == null) throw new BusinessException(BussinessErrorConstants.ConfigErrorConstant.CONFIG_NOT_FOUND);
            entity.UpdateValue(value);
            await _unitOfWork.SaveChangeAsync();

            if (entity.ConfigType == ConfigType.REGISTRATION_CUTOFF_DAY)
            {
                await _jobManager.ScheduleJobs();
            }

            return entity.Id;
        }
    }
}
