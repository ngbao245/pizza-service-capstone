using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetBookingById
{
    public class GetReservationByIdQueryHandler: IRequestHandler<GetReservationByIdQuery, ReservationDto>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _BookingRepository;

        public GetReservationByIdQueryHandler(IMapper mapper, IReservationRepository BookingRepository)
        {
            _mapper = mapper;
            _BookingRepository = BookingRepository;
        }

        public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _BookingRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<ReservationDto>(entity);
            return result;
        }
    }
}
