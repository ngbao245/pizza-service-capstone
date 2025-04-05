using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CancelReservation
{
    public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand>
    {
        private readonly IReservationService _reservationService;
        private readonly IReservationRepository _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelReservationCommandHandler(IReservationService reservationService, IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
        {
            _reservationService = reservationService;
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            var existingReservation = await _reservationRepository.GetSingleByIdAsync(request.ReservationId);
            if (existingReservation == null)
            {
                throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.BOOKING_NOT_FOUND);
            }
            var vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            var nowInVietnam = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);
            var timeUntilBooking = existingReservation.BookingTime - nowInVietnam;
            if (timeUntilBooking.TotalMinutes < 30)
            {
                throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.INVALID_BOOKING_TIME);
            }

            if (existingReservation.TableId != null)
            {
                throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.ASSIGNED_TABLE);
            }
            existingReservation.Cancel();
            await _unitOfWork.SaveChangeAsync();
        }

    }
}
