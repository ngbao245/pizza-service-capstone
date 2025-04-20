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

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTable
{
    public class GetListTableQueryHandler : IRequestHandler<GetListTableQuery, PaginatedResultDto<TableDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITableRepository _tableRepository;

        public GetListTableQueryHandler(IMapper mapper, ITableRepository tableRepository)
        {
            _mapper = mapper;
            _tableRepository = tableRepository;
        }

        public async Task<PaginatedResultDto<TableDto>> Handle(GetListTableQuery request, CancellationToken cancellationToken)
        {
            TableStatusEnum? tableStatus = string.IsNullOrEmpty(request.Status)
                ? null
                : Enum.TryParse(request.Status, true, out TableStatusEnum status)
                    ? status
                    : throw new BusinessException(BussinessErrorConstants.TableErrorConstant.INVALID_TABLE_STATUS);
            var query = _tableRepository.GetListAsNoTracking(
                x => (request.Code == null || x.Code == request.Code)
                && (request.Capacity == null || x.Capacity == request.Capacity)
                && (request.Status == null || x.Status == tableStatus)
                && (request.ZoneId == null || x.ZoneId == request.ZoneId)
                && (request.TableMergeId == null || x.TableMergeId == request.TableMergeId)
                && (request.CurrentOrderId == null || x.CurrentOrderId == request.CurrentOrderId)
                , includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<TableDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<TableDto>(result, totalCount);    
        }
    }
}
