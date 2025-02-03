using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetStaffZoneScheduleById
{
    public class GetStaffZoneScheduleByIdQueryHandler : IRequestHandler<GetStaffZoneScheduleByIdQuery, StaffZoneScheduleDto>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneScheduleRepository _StaffZoneScheduleRepository;

        public GetStaffZoneScheduleByIdQueryHandler(IMapper mapper, IStaffZoneScheduleRepository StaffZoneScheduleRepository)
        {
            _mapper = mapper;
            _StaffZoneScheduleRepository = StaffZoneScheduleRepository;
        }

        public async Task<StaffZoneScheduleDto> Handle(GetStaffZoneScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _StaffZoneScheduleRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<StaffZoneScheduleDto>(entity);
            return result;
        }
    }
}
