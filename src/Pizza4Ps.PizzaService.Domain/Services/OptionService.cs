using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using System.Diagnostics;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
	public class OptionService : IOptionService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IOptionRepository _optionRepository;

		public OptionService(IUnitOfWork unitOfWork, IOptionRepository optionRepository)
		{
			_unitOfWork = unitOfWork;
			_optionRepository = optionRepository;
		}

		public async Task<Guid> CreateAsync(string name, string description)
		{
			var entity = new Option(name, description);
			_optionRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _optionRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstant.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_optionRepository.HardDelete(entity);
				}
				else
				{
					_optionRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _optionRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstant.NOT_FOUND);
			foreach (var entity in entities)
			{
				_optionRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, string name, string description)
		{
			var entity = await _optionRepository.GetSingleByIdAsync(id);
			entity.UpdateOption(name, description);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
