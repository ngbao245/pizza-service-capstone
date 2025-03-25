using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class SizeService : DomainService, ISizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISizeRepository _sizeRepository;

        public SizeService(IUnitOfWork unitOfWork, ISizeRepository sizeRepository)
        {
            _unitOfWork = unitOfWork;
            _sizeRepository = sizeRepository;
        }

        public async Task<Guid> CreateAsync(string name, int diameterCm, string? description)
        {
            var entity = new Size(Guid.NewGuid(), name, diameterCm, description);
            _sizeRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
