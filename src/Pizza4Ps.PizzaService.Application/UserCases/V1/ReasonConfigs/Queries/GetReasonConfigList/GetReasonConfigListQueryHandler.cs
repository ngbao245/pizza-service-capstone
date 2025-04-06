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

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ReasonConfigs.Queries.GetReasonConfigList
{
    public class GetReasonConfigListQueryHandler : IRequestHandler<GetReasonConfigListQuery, PaginatedResultDto<ReasonConfigDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReasonConfigRepository _reasonConfigRepository;

        public GetReasonConfigListQueryHandler(IMapper mapper,
            IReasonConfigRepository reasonConfigRepository)
        {
            _mapper = mapper;
            _reasonConfigRepository = reasonConfigRepository;
        }
        public async Task<PaginatedResultDto<ReasonConfigDto>> Handle(GetReasonConfigListQuery request, CancellationToken cancellationToken)
        {
            ReasonConfigTypeEnum? reasonConfigType = null;
            if (!string.IsNullOrEmpty(request.ReasonConfigType))
            {
                if (!Enum.TryParse(request.ReasonConfigType, true, out ReasonConfigTypeEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.OrderItemErrorConstant.INVALID_ORDER_ITEM_STATUS);
                }
                reasonConfigType = parsedStatus;
            }
            var query = _reasonConfigRepository.GetListAsNoTracking(
                x => (request.SearchTerm == null ||
                      (!string.IsNullOrEmpty(x.Reason) && EF.Functions.Collate(x.Reason, "Vietnamese_CI_AI")
                     .ToLower().Contains(EF.Functions.Collate(request.SearchTerm, "Vietnamese_CI_AI").ToLower())))
                && (request.ReasonConfigType == null || x.ReasonType == reasonConfigType),
                includeProperties: request.IncludeProperties).AsSplitQuery();
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<ReasonConfigDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ReasonConfigDto>(result, totalCount);
        }
    }
}
