using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOption
{
    public class GetListOptionQueryHandler : IRequestHandler<GetListOptionQuery, PaginatedResultDto<OptionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;

        public GetListOptionQueryHandler(IMapper mapper, IOptionRepository optionRepository)
        {
            _mapper = mapper;
            _optionRepository = optionRepository;
        }

        public async Task<PaginatedResultDto<OptionDto>> Handle(GetListOptionQuery request, CancellationToken cancellationToken)
        {
            var query = _optionRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description)),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.OptionErrorConstant.OPTION_NOT_FOUND);
            var result = _mapper.Map<List<OptionDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<OptionDto>(result, totalCount);
        }
    }
}