using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Sizes.Queries.GetSizeById
{
    public class GetSizeByIdQueryHandler : IRequestHandler<GetSizeByIdQuery, SizeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _SizeRepository;

        public GetSizeByIdQueryHandler(IMapper mapper, ISizeRepository SizeRepository)
        {
            _mapper = mapper;
            _SizeRepository = SizeRepository;
        }

        public async Task<SizeDto> Handle(GetSizeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _SizeRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<SizeDto>(entity);
            return result;
        }
    }
}
