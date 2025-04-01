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

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Queries.GetListSwapWorkingSlot
{
    public class GetListSwapWorkingSlotQueryHandler : IRequestHandler<GetListSwapWorkingSlotQuery, PaginatedResultDto<SwapWorkingSlotDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISwapWorkingSlotRepository _swapworkingslotRepository;

        public GetListSwapWorkingSlotQueryHandler(IMapper mapper, ISwapWorkingSlotRepository swapworkingslotRepository)
        {
            _mapper = mapper;
            _swapworkingslotRepository = swapworkingslotRepository;
        }

        public async Task<PaginatedResultDto<SwapWorkingSlotDto>> Handle(GetListSwapWorkingSlotQuery request, CancellationToken cancellationToken)
        {
            SwapWorkingSlotStatusEnum? swapWorkingSlotStatus = null;
            if (!string.IsNullOrEmpty(request.Status))
            {
                if (!Enum.TryParse(request.Status, true, out SwapWorkingSlotStatusEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.INVALID_BOOKING_STATUS);
                }
                swapWorkingSlotStatus = parsedStatus;
            }


            var query = _swapworkingslotRepository.GetListAsNoTracking(
                x => (request.RequestDate == null || x.RequestDate == request.RequestDate)
                && (swapWorkingSlotStatus == null || x.Status == swapWorkingSlotStatus)
                && (request.WorkingDateFrom == null || x.WorkingDateFrom == request.WorkingDateFrom)
                && (request.EmployeeFromId == null || x.EmployeeFromId.Equals(request.EmployeeFromId))
                && (request.WorkingSlotFromId == null || x.WorkingSlotFromId.Equals(request.WorkingSlotFromId))
                && (request.WorkingDateTo == null || x.WorkingDateTo == request.WorkingDateTo)
                && (request.EmployeeToId == null || x.EmployeeToId.Equals(request.EmployeeToId))
                && (request.WorkingSlotToId == null || x.WorkingSlotToId.Equals(request.WorkingSlotToId))
                , includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<SwapWorkingSlotDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<SwapWorkingSlotDto>(result, totalCount);
        }
    }
}
