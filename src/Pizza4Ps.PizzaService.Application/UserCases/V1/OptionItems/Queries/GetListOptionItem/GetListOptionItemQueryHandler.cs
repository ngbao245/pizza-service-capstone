using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItem
{
    public class GetListOptionItemQueryHandler : IRequestHandler<GetListOptionItemQuery, PaginatedResultDto<OptionItemDto>>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemRepository _optionitemRepository;

		public GetListOptionItemQueryHandler(IMapper mapper, IOptionItemRepository optionitemRepository)
		{
			_mapper = mapper;
			_optionitemRepository = optionitemRepository;
		}

		public async Task<PaginatedResultDto<OptionItemDto>> Handle(GetListOptionItemQuery request, CancellationToken cancellationToken)
		{
			var query = _optionitemRepository.GetListAsNoTracking(
				x => (request.Name == null || x.Name.Contains(request.Name))
				&& (request.AdditionalPrice == null || x.AdditionalPrice == request.AdditionalPrice)
				&& (request.OptionId == null || x.OptionId == request.OptionId),
				includeProperties: request.IncludeProperties);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.OptionItemErrorConstant.OPTION_ITEM_NOT_FOUND);
			var result = _mapper.Map<List<OptionItemDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<OptionItemDto>(result, totalCount);
		}
	}
}
