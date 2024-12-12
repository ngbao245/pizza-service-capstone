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
    public class CategoryService : DomainService, ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
		{
			_unitOfWork = unitOfWork;
			_categoryRepository = categoryRepository;
		}

		public async Task<Guid> CreateAsync(string name, string description)
		{
			var entity = new Category(Guid.NewGuid(), name, description);
			_categoryRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _categoryRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_categoryRepository.HardDelete(entity);
				}
				else
				{
					_categoryRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _categoryRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_categoryRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, string name, string description)
		{
			var entity = await _categoryRepository.GetSingleByIdAsync(id);
			entity.UpdateCategory(name, description);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
