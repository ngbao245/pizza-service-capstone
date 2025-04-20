using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Queries.GetListStaffAbsence
{
    public class GetListStaffAbsenceQueryHandler : IRequestHandler<GetListStaffAbsenceQuery, PaginatedResultDto<StaffAbsenceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStaffAbsenceRepository _staffAbsenceRepository;

        public GetListStaffAbsenceQueryHandler(IMapper mapper, IStaffAbsenceRepository staffAbsenceRepository)
        {
            _mapper = mapper;
            _staffAbsenceRepository = staffAbsenceRepository;
        }

        public async Task<PaginatedResultDto<StaffAbsenceDto>> Handle(GetListStaffAbsenceQuery request, CancellationToken cancellationToken)
        {
            var query = _staffAbsenceRepository.GetListAsNoTracking(
                x => (request.StaffId == null || x.StaffId.Equals(request.StaffId))
                && (request.WorkingSlotId == null || x.WorkingSlotId.Equals(request.WorkingSlotId))
                && (request.AbsentDate == null || x.AbsentDate == request.AbsentDate),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StaffAbsenceDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<StaffAbsenceDto>(result, totalCount);
        }
    }
}
