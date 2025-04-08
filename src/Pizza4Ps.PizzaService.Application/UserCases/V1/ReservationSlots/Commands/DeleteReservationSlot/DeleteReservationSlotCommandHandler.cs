using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ReservationSlots.Commands.DeleteReservationSlot
{
    internal class DeleteReservationSlotCommandHandler : IRequestHandler<DeleteReservationSlotCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationSlotRepository _reservationSlotRepository;

        public DeleteReservationSlotCommandHandler(IReservationSlotRepository reservationSlotRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _reservationSlotRepository = reservationSlotRepository;
        }

        public async Task Handle(DeleteReservationSlotCommand request, CancellationToken cancellationToken)
        {
            var entities = await _reservationSlotRepository.GetListAsTracking(x => request.Ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (request.isHardDelete)
                {
                    _reservationSlotRepository.HardDelete(entity);
                }
                else
                {
                    _reservationSlotRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
