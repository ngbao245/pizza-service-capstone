using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetTableBookingById
{
    public class GetTableBookingByIdQueryHandler : IRequestHandler<GetTableBookingByIdQuery, TableBookingDto>
	{
		private readonly IMapper _mapper;
		private readonly ITableBookingRepository _TableBookingRepository;

		public GetTableBookingByIdQueryHandler(IMapper mapper, ITableBookingRepository TableBookingRepository)
		{
			_mapper = mapper;
			_TableBookingRepository = TableBookingRepository;
		}

		public async Task<TableBookingDto> Handle(GetTableBookingByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _TableBookingRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<TableBookingDto>(entity);
			return result;
		}
	}
}
