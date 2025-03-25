using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ReservationSlotService : DomainService, IReservationSlotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationSlotRepository _bookingSlotRepository;

        public ReservationSlotService(IReservationSlotRepository bookingSlotRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookingSlotRepository = bookingSlotRepository;
        }

        public async Task<Guid> CreateAsync(TimeSpan startTime, TimeSpan endTime, int capacity)
        {
            var entity = new ReservationSlot(
                startTime: startTime,
                endTime: endTime,
                capacity: capacity
                );
            _bookingSlotRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
