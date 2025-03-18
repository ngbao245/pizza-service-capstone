using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Sizes.Queries.GetListSize
{
    public class GetListSizeQueryHandler : IRequestHandler<GetListSizeQuery, PaginatedResultDto<SizeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _SizeRepository;

        public GetListSizeQueryHandler(IMapper mapper, ISizeRepository SizeRepository)
        {
            _mapper = mapper;
            _SizeRepository = SizeRepository;
        }

        public async Task<PaginatedResultDto<SizeDto>> Handle(GetListSizeQuery request, CancellationToken cancellationToken)
        {
            var query = _SizeRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description))
                ,
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.SizeErrorConstant.SIZE_NOT_FOUND);
            var result = _mapper.Map<List<SizeDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<SizeDto>(result, totalCount);
        }
    }
}
