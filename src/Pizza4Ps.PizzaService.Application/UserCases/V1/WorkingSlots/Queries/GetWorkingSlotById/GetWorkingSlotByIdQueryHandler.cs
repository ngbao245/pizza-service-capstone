using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Queries.GetWorkingSlotById
{
    public class GetWorkingSlotByIdQueryHandler : IRequestHandler<GetWorkingSlotByIdQuery, WorkingSlotDto>
    {
        private readonly IMapper _mapper;
        private readonly IWorkingSlotRepository _WorkingSlotRepository;

        public GetWorkingSlotByIdQueryHandler(IMapper mapper, IWorkingSlotRepository WorkingSlotRepository)
        {
            _mapper = mapper;
            _WorkingSlotRepository = WorkingSlotRepository;
        }

        public async Task<WorkingSlotDto> Handle(GetWorkingSlotByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _WorkingSlotRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<WorkingSlotDto>(entity);
            return result;
        }
    }
}
