using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class BookingService : DomainService, IBookingService
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingSlotRepository _bookingSlotRepository;
        private readonly IBookingRepository _bookingRepository;

		public BookingService(IUnitOfWork unitOfWork, IBookingRepository bookingRepository
			, IBookingSlotRepository bookingSlotRepository)
		{
			_unitOfWork = unitOfWork;
            _bookingSlotRepository = bookingSlotRepository;
            _bookingRepository = bookingRepository;
		}

		public async Task<Guid> CreateAsync(Guid? customerCode, string customerName, string phoneNumber, DateTime bookingTime, int numberOfPeople)
		{
            var slot = await _bookingSlotRepository.GetListAsNoTracking(x 
				=> x.StartTime <= bookingTime.TimeOfDay && x.EndTime > bookingTime.TimeOfDay).FirstOrDefaultAsync();
			if (slot == null) throw new BusinessException(BussinessErrorConstants.BookingSlotErrorConstant.BOOKING_SLOT_NOT_FOUND);
			// Lấy các booking đã được đặt cho slot đó trong ngày
			var existingBookings = await _bookingRepository.GetListAsNoTracking(x
				=> x.BookingTime.Date == bookingTime.Date &&
					x.BookingTime.TimeOfDay >= slot.StartTime &&
					x.BookingTime.TimeOfDay < slot.EndTime &&
					x.BookingStatus == BookingStatusEnum.CheckedIn).ToListAsync();
            // Chỉ lấy các booking có BookingTime thuộc slot của cùng ngày
            int total = existingBookings.Sum(b => b.NumberOfPeople);
            if (total + numberOfPeople > slot.Capacity) throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.BOOKING_SLOT_FULL);
            // Nếu hợp lệ, tạo booking
            var booking = new Booking(
				bookingTime: bookingTime,
				numberOfPeople: numberOfPeople,
				customerCode: customerCode,
				customerName: customerName,
				phoneNumber: phoneNumber);
            _bookingRepository.Add(booking);
            await _unitOfWork.SaveChangeAsync();
            return booking.Id;
        }	

        public Task<Guid> CreateAsync(string name, string description)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
            throw new NotImplementedException();
        }

		public async Task RestoreAsync(List<Guid> ids)
		{
            throw new NotImplementedException();
        }

		public async Task<Guid> UpdateAsync(Guid id, DateTime bookingDate, int guestCount, string status, Guid customerId)
		{
            throw new NotImplementedException();
        }
	}
}
