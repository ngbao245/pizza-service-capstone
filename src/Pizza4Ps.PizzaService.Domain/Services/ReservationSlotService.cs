using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
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
            var reservationSlotExisted = await _bookingSlotRepository.GetListAsNoTracking(x =>
                (startTime > x.StartTime && startTime < x.EndTime) ||
                (endTime > x.StartTime && endTime < x.EndTime) ||
                (startTime == x.StartTime && endTime == x.EndTime)).ToListAsync();
            if (reservationSlotExisted.Any())
            {
                throw new BusinessException("Thời gian cấu hình bị chồng chéo vào nhau, vui lòng kiểm tra lại");
            }
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
