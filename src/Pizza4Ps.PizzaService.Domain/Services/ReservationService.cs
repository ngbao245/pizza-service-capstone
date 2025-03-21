using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ReservationService : DomainService, IReservationService
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationSlotRepository _bookingSlotRepository;
        private readonly IReservationRepository _bookingRepository;
		private readonly ITableRepository _tableRepository;

		public ReservationService(IUnitOfWork unitOfWork, IReservationRepository bookingRepository
			, IReservationSlotRepository bookingSlotRepository, ITableRepository tableRepository)
		{
			_unitOfWork = unitOfWork;
            _bookingSlotRepository = bookingSlotRepository;
            _bookingRepository = bookingRepository;
			_tableRepository = tableRepository;
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
					x.BookingStatus == ReservationStatusEnum.Created).ToListAsync();

            // Chỉ lấy các booking có BookingTime thuộc slot của cùng ngày
            int total = existingBookings.Sum(b => b.NumberOfPeople);
            if (total + numberOfPeople > slot.Capacity) throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.BOOKING_SLOT_FULL);
            // Nếu hợp lệ, tạo booking
            var booking = new Reservation(
				bookingTime: bookingTime,
				numberOfPeople: numberOfPeople,
				customerCode: customerCode,
				customerName: customerName,
				phoneNumber: phoneNumber,
		        tableId: null
				);
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

		public async Task<bool> AssignTableAsync(Guid reservationId, Guid tableId)
		{
			var existingTable = await _tableRepository.GetSingleByIdAsync(tableId);
			if (existingTable == null)
			{
				return false;
			}
			if (existingTable.Status == TableStatusEnum.Reserved || existingTable.Status == TableStatusEnum.Locked)
			{
				throw new BusinessException(BussinessErrorConstants.TableErrorConstant.INVALID_TABLE_STATUS);
			}
			var existingReservation = await _bookingRepository.GetSingleByIdAsync(reservationId);
			if (existingReservation == null)
			{
				throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
			}
			if (existingReservation.BookingStatus == ReservationStatusEnum.Cancelled)
			{
				throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.INVALID_BOOKING_STATUS);
			}

			existingReservation.TableId = existingTable.Id;
			_bookingRepository.Update(existingReservation);
			existingTable.SetBooked();
			_tableRepository.Update(existingTable);
			await _unitOfWork.SaveChangeAsync();
			return true;
		}

        public async Task<bool> CheckInAsync(Guid reservationId)
        {
            var existingReservation = await _bookingRepository.GetSingleByIdAsync(reservationId);
            if (existingReservation == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            }
            if (existingReservation.BookingStatus == ReservationStatusEnum.Cancelled)
            {
                throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.INVALID_BOOKING_STATUS);
            }
            if (existingReservation.TableId == null)
            {
                throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.NOT_ASSIGNED_TABLE);
            }
            var existingTable = await _tableRepository.GetSingleByIdAsync(existingReservation.TableId.Value);
            if (existingTable == null)
            {
                return false;
            }
            if (existingTable.Status != TableStatusEnum.Reserved)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.INVALID_TABLE_STATUS);
            }
            existingReservation.Checkedin();
            existingTable.SetOpening();

            _bookingRepository.Update(existingReservation);
            _tableRepository.Update(existingTable);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}
