using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterById
{
    public class GetWorkshopRegisterByIdQueryHandler : IRequestHandler<GetWorkshopRegisterByIdQuery, WorkshopRegisterDto>
    {
        private readonly IMapper _mapper;
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;

        public GetWorkshopRegisterByIdQueryHandler(IMapper mapper, IWorkshopRegisterRepository workshopRegisterRepository)
        {
            _mapper = mapper;
            _workshopRegisterRepository = workshopRegisterRepository;
        }
        public async Task<WorkshopRegisterDto> Handle(GetWorkshopRegisterByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _workshopRegisterRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<WorkshopRegisterDto>(entity);
            return result;
        }
    }
}
