using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetListCategoryIgnoreQueryFilter
{
    public class GetListCategoryIgnoreQueryFilterQueryHandler : IRequestHandler<GetListCategoryIgnoreQueryFilterQuery, PaginatedResultDto<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _CategoryRepository;

        public GetListCategoryIgnoreQueryFilterQueryHandler(IMapper mapper, ICategoryRepository CategoryRepository)
        {
            _mapper = mapper;
            _CategoryRepository = CategoryRepository;
        }

        public async Task<PaginatedResultDto<CategoryDto>> Handle(GetListCategoryIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _CategoryRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description))
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<CategoryDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<CategoryDto>(result, totalCount);
        }
    }
}
