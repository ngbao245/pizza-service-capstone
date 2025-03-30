using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Shifts.Queries.GetListShift
{
    public class GetListShiftQueryHandler : IRequestHandler<GetListShiftQuery, PaginatedResultDto<ShiftDto>>
    {
        private readonly IMapper _mapper;
        private readonly IShiftRepository _ShiftRepository;

        public GetListShiftQueryHandler(IMapper mapper, IShiftRepository ShiftRepository)
        {
            _mapper = mapper;
            _ShiftRepository = ShiftRepository;
        }

        public async Task<PaginatedResultDto<ShiftDto>> Handle(GetListShiftQuery request, CancellationToken cancellationToken)
        {
            var query = _ShiftRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description))
                ,
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<ShiftDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ShiftDto>(result, totalCount);
        }
    }
}
