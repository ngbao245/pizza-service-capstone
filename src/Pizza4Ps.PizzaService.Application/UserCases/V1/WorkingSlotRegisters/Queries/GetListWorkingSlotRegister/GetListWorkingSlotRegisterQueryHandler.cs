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

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Queries.GetListWorkingSlotRegister
{
    public class GetListWorkingSlotRegisterQueryHandler : IRequestHandler<GetListWorkingSlotRegisterQuery, PaginatedResultDto<WorkingSlotRegisterDto>>
    {
        private readonly IMapper _mapper;
        private readonly IWorkingSlotRegisterRepository _WorkingSlotRegisterRepository;

        public GetListWorkingSlotRegisterQueryHandler(IMapper mapper, IWorkingSlotRegisterRepository WorkingSlotRegisterRepository)
        {
            _mapper = mapper;
            _WorkingSlotRegisterRepository = WorkingSlotRegisterRepository;
        }

        public async Task<PaginatedResultDto<WorkingSlotRegisterDto>> Handle(GetListWorkingSlotRegisterQuery request, CancellationToken cancellationToken)
        {
            WorkingSlotRegisterStatusEnum? workingSlotRegisterStatus = null;
            if (!string.IsNullOrEmpty(request.Status))
            {
                if (!Enum.TryParse(request.Status, true, out WorkingSlotRegisterStatusEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.INVALID_WORKING_SLOT_REGISTER_STATUS);
                }
                workingSlotRegisterStatus = parsedStatus;
            }

            var query = _WorkingSlotRegisterRepository.GetListAsNoTracking(
                x => (request.StaffName == null || x.StaffName.Contains(request.StaffName))
                && (request.WorkingDate == null || x.WorkingDate == request.WorkingDate)
                && (workingSlotRegisterStatus == null || x.Status == workingSlotRegisterStatus)
                && (request.StaffId == null || x.StaffId.Equals(request.StaffId))
                && (request.WorkingSlotId == null || x.WorkingSlotId.Equals(request.WorkingSlotId)),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<WorkingSlotRegisterDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<WorkingSlotRegisterDto>(result, totalCount);
        }
    }
}