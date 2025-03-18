using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Queries.GetWorkshopById
{
    public class GetWorkshopByIdQueryHandler : IRequestHandler<GetWorkshopByIdQuery, WorkshopDto>
    {
        private readonly IMapper _mapper;
        private readonly IWorkshopRepository _workshopRepository;

        public GetWorkshopByIdQueryHandler(IMapper mapper, IWorkshopRepository workshopRepository)
        {
            _mapper = mapper;
            _workshopRepository = workshopRepository;
        }

        public async Task<WorkshopDto> Handle(GetWorkshopByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _workshopRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<WorkshopDto>(entity);
            return result;
        }
    }
}
