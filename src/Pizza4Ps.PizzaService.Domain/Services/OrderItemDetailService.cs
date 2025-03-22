using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class OrderItemDetailService : DomainService, IOrderItemDetailService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IOrderItemDetailRepository _orderItemDetailRepository;

        public OrderItemDetailService(IUnitOfWork unitOfWork, IOrderItemDetailRepository orderItemDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _orderItemDetailRepository = orderItemDetailRepository;
        }

        public async Task<Guid> CreateAsync(string name, decimal additionalPrice, Guid orderItemId)
		{
			var entity = new OrderItemDetail(Guid.NewGuid(), name, additionalPrice, orderItemId);
            _orderItemDetailRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _orderItemDetailRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
                    _orderItemDetailRepository.HardDelete(entity);
				}
				else
				{
                    _orderItemDetailRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _orderItemDetailRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_orderItemDetailRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, string name, decimal additionalPrice, Guid orderItemId)
		{
			var entity = await _orderItemDetailRepository.GetSingleByIdAsync(id);
			entity.UpdateOptionItemOrderItem(name, additionalPrice, orderItemId);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
