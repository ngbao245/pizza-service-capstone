using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Queries.GetSwapWorkingSlotById
{
    public class GetSwapWorkingSlotByIdQueryHandler : IRequestHandler<GetSwapWorkingSlotByIdQuery, SwapWorkingSlotDto>
    {
        private readonly IMapper _mapper;
        private readonly ISwapWorkingSlotRepository _swapworkingslotRepository;

        public GetSwapWorkingSlotByIdQueryHandler(IMapper mapper, ISwapWorkingSlotRepository swapworkingslotRepository)
        {
            _mapper = mapper;
            _swapworkingslotRepository = swapworkingslotRepository;
        }
        public async Task<SwapWorkingSlotDto> Handle(GetSwapWorkingSlotByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _swapworkingslotRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<SwapWorkingSlotDto>(entity);
            return result;
        }
    }
}
