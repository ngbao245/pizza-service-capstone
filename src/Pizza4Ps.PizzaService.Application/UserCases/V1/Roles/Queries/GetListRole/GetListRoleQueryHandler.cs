using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Roles.Queries.GetListRole
{
    public class GetListRoleQueryHandler : IRequestHandler<GetListRoleQuery, PaginatedResultDto<RoleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _RoleRepository;

        public GetListRoleQueryHandler(IMapper mapper, IRoleRepository RoleRepository)
        {
            _mapper = mapper;
            _RoleRepository = RoleRepository;
        }

        public async Task<PaginatedResultDto<RoleDto>> Handle(GetListRoleQuery request, CancellationToken cancellationToken)
        {
            var query = _RoleRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name)),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.RoleErrorConstant.ROLE_NOT_FOUND);
            var result = _mapper.Map<List<RoleDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<RoleDto>(result, totalCount);
        }
    }
}
