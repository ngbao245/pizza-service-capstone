using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Days.Queries.GetDayById
{
    public class GetDayByIdQueryHandler : IRequestHandler<GetDayByIdQuery, DayDto>
    {
        private readonly IMapper _mapper;
        private readonly IDayRepository _DayRepository;

        public GetDayByIdQueryHandler(IMapper mapper, IDayRepository DayRepository)
        {
            _mapper = mapper;
            _DayRepository = DayRepository;
        }

        public async Task<DayDto> Handle(GetDayByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _DayRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<DayDto>(entity);
            return result;
        }
    }
}
