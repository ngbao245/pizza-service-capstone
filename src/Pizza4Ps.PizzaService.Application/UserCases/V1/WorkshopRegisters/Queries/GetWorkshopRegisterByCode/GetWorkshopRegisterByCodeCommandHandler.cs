using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterByCode
{
    public class GetWorkshopRegisterByCodeCommandHandler : IRequestHandler<GetWorkshopRegisterByCodeCommand, WorkshopRegisterDto>
    {
        private readonly IMapper _mapper;
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;

        public GetWorkshopRegisterByCodeCommandHandler(IMapper mapper, IWorkshopRegisterRepository workshopRegisterRepository)
        {
            _mapper = mapper;
            _workshopRegisterRepository = workshopRegisterRepository;
        }
        public async Task<WorkshopRegisterDto> Handle(GetWorkshopRegisterByCodeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _workshopRegisterRepository.GetSingleAsync(x => x.Code == request.Code , request.includeProperties);
            var result = _mapper.Map<WorkshopRegisterDto>(entity);
            return result;
        }
    }
}
