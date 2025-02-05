using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdQueryHandler: IRequestHandler<GetBookingByIdQuery, BookingDto>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _BookingRepository;

        public GetBookingByIdQueryHandler(IMapper mapper, IBookingRepository BookingRepository)
        {
            _mapper = mapper;
            _BookingRepository = BookingRepository;
        }

        public async Task<BookingDto> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _BookingRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<BookingDto>(entity);
            return result;
        }
    }
}
