using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class VoucherTypeService : DomainService, IVoucherTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVoucherTypeRepository _voucherTypeRepository;

        public VoucherTypeService(IUnitOfWork unitOfWork, IVoucherTypeRepository voucherTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _voucherTypeRepository = voucherTypeRepository;
        }

        public async Task<Guid> CreateAsync(string name, string description, int totalQuantity)
        {
            throw new NotImplementedException();
            //var entity = new VoucherBatch(Guid.NewGuid(), name, description, totalQuantity);
            //_voucherTypeRepository.Add(entity);
            //await _unitOfWork.SaveChangeAsync();
            //return entity.Id;
        }
    }
}
