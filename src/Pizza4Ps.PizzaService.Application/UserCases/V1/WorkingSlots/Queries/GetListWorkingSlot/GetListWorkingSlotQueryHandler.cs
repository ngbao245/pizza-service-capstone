using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Queries.GetListWorkingSlot
{
    public class GetListWorkingSlotQueryHandler : IRequestHandler<GetListWorkingSlotQuery, PaginatedResultDto<WorkingSlotDto>>
    {
        private readonly IMapper _mapper;
        private readonly IWorkingSlotRepository _WorkingSlotRepository;

        public GetListWorkingSlotQueryHandler(IMapper mapper, IWorkingSlotRepository WorkingSlotRepository)
        {
            _mapper = mapper;
            _WorkingSlotRepository = WorkingSlotRepository;
        }

        public async Task<PaginatedResultDto<WorkingSlotDto>> Handle(GetListWorkingSlotQuery request, CancellationToken cancellationToken)
        {
            var query = _WorkingSlotRepository.GetListAsNoTracking(
                x => (request.ShiftName == null || x.ShiftName.Contains(request.ShiftName))
                && (request.DayName == null || x.DayName.Contains(request.DayName))
                && (request.ShiftStart != null && request.ShiftEnd == null) ? x.ShiftStart >= request.ShiftStart :
                (request.ShiftEnd != null && request.ShiftStart == null) ? x.ShiftEnd <= request.ShiftEnd :
                (request.ShiftStart != null && request.ShiftEnd != null) ? (x.ShiftStart >= request.ShiftStart && x.ShiftEnd <= request.ShiftEnd) : true
                && (request.DayId == null || x.DayId == request.DayId) && (request.ShiftId == null || x.ShiftId == request.ShiftId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_NOT_FOUND);
            var result = _mapper.Map<List<WorkingSlotDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<WorkingSlotDto>(result, totalCount);
        }
    }
}
