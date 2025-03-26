using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Queries.GetStaffById
{
    public class GetStaffByIdQueryHandler : IRequestHandler<GetStaffByIdQuery, StaffDto>
	{
		private readonly IMapper _mapper;
		private readonly IStaffRepository _staffRepository;

		public GetStaffByIdQueryHandler(IMapper mapper, IStaffRepository staffRepository)
		{
			_mapper = mapper;
			_staffRepository = staffRepository;
		}


        public async Task<StaffDto> Handle(GetStaffByIdQuery request, CancellationToken cancellationToken)
		{
            var includeProperties = string.IsNullOrEmpty(request.includeProperties) ? "AppUser" : $"{request.includeProperties},AppUser";
            var entity = await _staffRepository.GetSingleByIdAsync(request.Id, includeProperties);
			var result = _mapper.Map<StaffDto>(entity);
			return result;
		}
	}
}
