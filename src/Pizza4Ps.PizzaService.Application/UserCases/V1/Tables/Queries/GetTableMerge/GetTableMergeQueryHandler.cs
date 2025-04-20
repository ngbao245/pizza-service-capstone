using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetTableMerge
{
    public class GetTableMergeQueryHandler : IRequestHandler<GetTableMergeQuery, PaginatedResultDto<TableMergeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITableMergeRepository _tableMergeRepository;

        public GetTableMergeQueryHandler(IMapper mapper, ITableMergeRepository tableMergeRepository)
        {
            _mapper = mapper;
            _tableMergeRepository = tableMergeRepository;
        }

        public async Task<PaginatedResultDto<TableMergeDto>> Handle(GetTableMergeQuery request, CancellationToken cancellationToken)
        {
            var query = _tableMergeRepository.GetListAsNoTracking();
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<TableMergeDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<TableMergeDto>(result, totalCount);
        }
    }
}
