using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetStaffZoneScheduleById;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Queries.GetStaffAbsenceById
{
    public class GetStaffAbsenceByIdQueryHandler : IRequestHandler<GetStaffAbsenceByIdQuery, StaffAbsenceDto>
    {
        private readonly IMapper _mapper;
        private readonly IStaffAbsenceRepository _staffAbsenceRepository;

        public GetStaffAbsenceByIdQueryHandler(IMapper mapper, IStaffAbsenceRepository staffAbsenceRepository)
        {
            _mapper = mapper;
            _staffAbsenceRepository = staffAbsenceRepository;
        }

        public async Task<StaffAbsenceDto> Handle(GetStaffAbsenceByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _staffAbsenceRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<StaffAbsenceDto>(entity);
            return result;
        }
    }
}
