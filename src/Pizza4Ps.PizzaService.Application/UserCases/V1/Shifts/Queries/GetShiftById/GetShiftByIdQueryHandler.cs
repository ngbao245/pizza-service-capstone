using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Shifts.Queries.GetShiftById
{
    public class GetShiftByIdQueryHandler : IRequestHandler<GetShiftByIdQuery, ShiftDto>
    {
        private readonly IMapper _mapper;
        private readonly IShiftRepository _ShiftRepository;

        public GetShiftByIdQueryHandler(IMapper mapper, IShiftRepository ShiftRepository)
        {
            _mapper = mapper;
            _ShiftRepository = ShiftRepository;
        }

        public async Task<ShiftDto> Handle(GetShiftByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _ShiftRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<ShiftDto>(entity);
            return result;
        }
    }
}
