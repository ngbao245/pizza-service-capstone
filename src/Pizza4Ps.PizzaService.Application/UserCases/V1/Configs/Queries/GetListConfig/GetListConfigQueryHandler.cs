using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Configs.Queries.GetListConfig
{
    public class GetListConfigQueryHandler : IRequestHandler<GetListConfigQuery, PaginatedResultDto<ConfigDto>>
    {
        private readonly IMapper _mapper;
        private readonly IConfigRepository _configRepository;

        public GetListConfigQueryHandler(IMapper mapper, IConfigRepository configRepository)
        {
            _mapper = mapper;
            _configRepository = configRepository;
        }

        public async Task<PaginatedResultDto<ConfigDto>> Handle(GetListConfigQuery request, CancellationToken cancellationToken)
        {
            ConfigType? configType = null;
            if (!string.IsNullOrEmpty(request.ConfigType))
            {
                if (!Enum.TryParse(request.ConfigType, true, out ConfigType parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.ConfigErrorConstant.CONFIG_INVALID);
                }
                configType = parsedStatus;
            }

            var query = _configRepository.GetListAsNoTracking(
                x => (configType == null || x.ConfigType == configType)
                && (request.Key == null || x.Key.Contains(request.Key)),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<ConfigDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ConfigDto>(result, totalCount);

        }
    }
}
