using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Queries.GetWorkingSlotRegisterById;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Queries.GetWorkingSlotRegisterById
{
    public class GetWorkingSlotRegisterByIdQueryHandler : IRequestHandler<GetWorkingSlotRegisterByIdQuery, WorkingSlotRegisterDto>
    {
        private readonly IMapper _mapper;
        private readonly IWorkingSlotRegisterRepository _WorkingSlotRegisterRepository;

        public GetWorkingSlotRegisterByIdQueryHandler(IMapper mapper, IWorkingSlotRegisterRepository WorkingSlotRegisterRepository)
        {
            _mapper = mapper;
            _WorkingSlotRegisterRepository = WorkingSlotRegisterRepository;
        }

        public async Task<WorkingSlotRegisterDto> Handle(GetWorkingSlotRegisterByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _WorkingSlotRegisterRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<WorkingSlotRegisterDto>(entity);
            return result;
        }
    }
}
