using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTableIgnoreQueryFilter
{
    public class GetListTableIgnoreQueryFilterQueryHandler : IRequestHandler<GetListTableIgnoreQueryFilterQuery, PaginatedResultDto<TableDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITableRepository _tableRepository;

        public GetListTableIgnoreQueryFilterQueryHandler(IMapper mapper, ITableRepository tableRepository)
        {
            _mapper = mapper;
            _tableRepository = tableRepository;
        }

        public async Task<PaginatedResultDto<TableDto>> Handle(GetListTableIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            TableStatusEnum? tableStatus = string.IsNullOrEmpty(request.Status)
                ? null
                : Enum.TryParse(request.Status, true, out TableStatusEnum status)
                    ? status
                    : throw new BusinessException(BussinessErrorConstants.TableErrorConstant.INVALID_TABLE_STATUS);
            var query = _tableRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                x => (request.TableNumber == null || x.TableNumber == request.TableNumber)
                && (request.Capacity == null || x.Capacity == request.Capacity)
                && (request.Status == null || x.Status == tableStatus)
                && (request.ZoneId == null || x.ZoneId == request.ZoneId)
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<TableDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<TableDto>(result, totalCount);
        }
    }
}
