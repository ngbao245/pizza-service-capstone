using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.ChangeTableReservation
{
    public class ChangeTableReservationCommandHandler : IRequestHandler<ChangeTableReservationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;

        public ChangeTableReservationCommandHandler(IReservationRepository reservationRepository,
            ITableRepository tableRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
        }
        public async Task Handle(ChangeTableReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetSingleByIdAsync(request.ReservationId);
            if (reservation == null)
            {
                throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.BOOKING_NOT_FOUND);
            }
            if (reservation.TableId == null)
            {
                throw new BusinessException("Yêu cầu đặt chỗ chưa được sắp xếp bàn");
            }
            var table = await _tableRepository.GetSingleByIdAsync(request.NewTableId);
            if (table == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            }

        }
    }
}
