using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Queries.CheckReservation
{
    public class CheckReservationQueryHandler : IRequestHandler<CheckReservationQuery, PaginatedResultDto<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public CheckReservationQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResultDto<ReservationDto>> Handle(CheckReservationQuery request, CancellationToken cancellationToken)
        {
            var query = _reservationRepository.GetListAsNoTracking(
                r =>(string.IsNullOrEmpty(request.PhoneNumber) || r.PhoneNumber == request.PhoneNumber)
                && r.BookingTime.Date == (request.BookingDate.HasValue ? request.BookingDate.Value.Date : DateTime.UtcNow.Date),
                includeProperties: "Table");


            var totalCount = await query.CountAsync();

            //Pagination
            var reservations = await query
                .Skip(request.SkipCount)
                .Take(request.TakeCount)
                .ToListAsync(cancellationToken);


            var reservationDtos = _mapper.Map<List<ReservationDto>>(reservations);

            return new PaginatedResultDto<ReservationDto>(reservationDtos, totalCount);
        }
    }
}
