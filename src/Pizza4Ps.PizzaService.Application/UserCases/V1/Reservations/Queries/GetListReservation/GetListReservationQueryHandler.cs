using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBooking
{
    public class GetListBookingQueryHandler : IRequestHandler<GetListReservationQuery, PaginatedResultDto<ReservationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _BookingRepository;

        public GetListBookingQueryHandler(IMapper mapper, IReservationRepository BookingRepository)
        {
            _mapper = mapper;
            _BookingRepository = BookingRepository;
        }

        public async Task<PaginatedResultDto<ReservationDto>> Handle(GetListReservationQuery request, CancellationToken cancellationToken)
        {
            ReservationStatusEnum? bookingStatus = null;
            if (!string.IsNullOrEmpty(request.BookingStatus))
            {
                if (!Enum.TryParse(request.BookingStatus, true, out ReservationStatusEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.INVALID_BOOKING_STATUS);
                }
                bookingStatus = parsedStatus;
            }

            var query = _BookingRepository.GetListAsNoTracking(
                x => (request.CustomerCode == null || x.CustomerId.Equals(request.CustomerCode))
                && (request.PhoneNumber == null || x.PhoneNumber.Equals(request.PhoneNumber))
                && (request.BookingTime == null || x.BookingTime.Date == request.BookingTime.Value.Date)
                && (bookingStatus == null || x.BookingStatus == bookingStatus),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<ReservationDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ReservationDto>(result, totalCount);
        }
    }
}
