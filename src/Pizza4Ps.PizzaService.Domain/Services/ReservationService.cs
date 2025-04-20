using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ReservationService : DomainService, IReservationService
    {
        private readonly ITableAssignReservationRepository _tableAssignReservationRepository;
        private readonly IConfigRepository _configRepository;
        private readonly IBackgroundJobService _backgroundJobService;
        private readonly IRealTimeNotifier _realTimeNotifier;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationSlotRepository _bookingSlotRepository;
        private readonly IReservationRepository _bookingRepository;
        private readonly ITableRepository _tableRepository;

        public ReservationService(IUnitOfWork unitOfWork, IReservationRepository bookingRepository
            , IReservationSlotRepository bookingSlotRepository, ITableRepository tableRepository,
            ICustomerRepository customerRepository,
            IRealTimeNotifier realTimeNotifier,
            IBackgroundJobService backgroundJobService,
            IConfigRepository configRepository,
            ITableAssignReservationRepository tableAssignReservationRepository)
        {
            _tableAssignReservationRepository = tableAssignReservationRepository;
            _configRepository = configRepository;
            _backgroundJobService = backgroundJobService;
            _realTimeNotifier = realTimeNotifier;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _bookingSlotRepository = bookingSlotRepository;
            _bookingRepository = bookingRepository;
            _tableRepository = tableRepository;
        }

        public async Task<Guid> CreateAsync(string customerName, string phoneNumber, string phoneOtp, DateTime bookingTime, int numberOfPeople)
        {
            var slot = await _bookingSlotRepository.GetListAsNoTracking(x
                => x.StartTime <= bookingTime.TimeOfDay && x.EndTime > bookingTime.TimeOfDay).FirstOrDefaultAsync();
            if (slot == null) throw new BusinessException(BussinessErrorConstants.BookingSlotErrorConstant.BOOKING_SLOT_NOT_FOUND);
            // Lấy các booking đã được đặt cho slot đó trong ngày
            var existingBookings = await _bookingRepository.GetListAsNoTracking(x
                => x.BookingTime.Date == bookingTime.Date &&
                    x.BookingTime.TimeOfDay >= slot.StartTime &&
                    x.BookingTime.TimeOfDay < slot.EndTime &&
                    x.BookingStatus != ReservationStatusEnum.Cancelled).ToListAsync();

            int total = existingBookings.Count();
            ReservationPriorityStatus priorityStatus = ReservationPriorityStatus.Priority;
            if (total + 1 > slot.Capacity)
            {
                priorityStatus = ReservationPriorityStatus.NonPriority;
            }
            // Nếu hợp lệ, tạo booking

            var customer = await _customerRepository.GetSingleAsync(x => x.Phone == phoneNumber);

            if (customer == null)
            {
                customer = new Customer(Guid.NewGuid(), customerName, phoneNumber);
                _customerRepository.Add(customer);
            }
            if (customer.PhoneOtp != phoneOtp)
            {
                throw new BusinessException("Phone OTP is not valid");
            }

            var booking = new Reservation(
            bookingTime: bookingTime,
            numberOfPeople: numberOfPeople,
            customerId: customer.Id,
            customerName: customerName,
            phoneNumber: phoneNumber,
            tableId: null,
            reservationPriorityStatus: priorityStatus
            );

            _bookingRepository.Add(booking);
            await _unitOfWork.SaveChangeAsync();
            await _realTimeNotifier.CreatedReservationAsync(booking);
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

        public async Task<bool> AssignTableAsync(Guid reservationId, List<Guid> tableIds)
        {
            var existingTables = await _tableRepository.GetListAsTracking(x => tableIds.Contains(x.Id)).ToListAsync();
            if (existingTables == null)
            {
                return false;
            }
            foreach (var table in existingTables)
            {
                if (table.Status != TableStatusEnum.Closing)
                {
                    throw new BusinessException(BussinessErrorConstants.TableErrorConstant.UNAVAILABLE_TABLE_STATUS);
                }
            }
            var existingReservation = await _bookingRepository.GetSingleByIdAsync(reservationId);
            if (existingReservation == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            }
            if (existingReservation.BookingStatus == ReservationStatusEnum.Cancelled)
            {
                throw new BusinessException("Yêu cầu đặt bàn đã bị huỷ");
            }
            if (existingReservation.BookingStatus == ReservationStatusEnum.Checkedin)
            {
                throw new BusinessException("Yêu cầu đặt bàn đã hoàn tất");
            }
            var configTimePreviousBooking = await _configRepository.GetSingleAsync(x => x.ConfigType == ConfigType.BOOKING_DATE_PREVIOUS_NOTIFY);
            double configTimePreviousBookingDouble = 30;
            if (configTimePreviousBooking != null)
            {
                configTimePreviousBookingDouble = double.Parse(configTimePreviousBooking.Value);
            }
            if (DateTime.Now < existingReservation.BookingTime.AddMinutes(-configTimePreviousBookingDouble))
            {
                throw new BusinessException($"Bạn không thể sắp xếp bàn cho việc đặt bàn trước quá {configTimePreviousBookingDouble.ToString()} phút");
            }
            foreach (var table in existingTables)
            {
                var tableAssignReservation = new TableAssignReservation
                {
                    ReservationId = reservationId,
                    Id = Guid.NewGuid(),
                    TableId = table.Id,
                };
                table.SetBooked(reservationId);
                _tableRepository.Update(table);
                _tableAssignReservationRepository.Add(tableAssignReservation);
            }
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
        public async Task<bool> UnAssignTableAsync(Guid reservationId, List<Guid> tableIds)
        {
            var existingTables = await _tableRepository.GetListAsTracking(x => tableIds.Contains(x.Id)).ToListAsync();
            if (existingTables == null)
            {
                return false;
            }
            var existingReservation = await _bookingRepository.GetSingleByIdAsync(reservationId);
            if (existingReservation == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            }
            if (existingReservation.BookingStatus == ReservationStatusEnum.Cancelled)
            {
                throw new BusinessException("Yêu cầu đặt bàn đã bị huỷ");
            }
            if (existingReservation.BookingStatus == ReservationStatusEnum.Checkedin)
            {
                throw new BusinessException("Yêu cầu đặt bàn đã hoàn tất");
            }
            var configTimePreviousBooking = await _configRepository.GetSingleAsync(x => x.ConfigType == ConfigType.BOOKING_DATE_PREVIOUS_NOTIFY);
            double configTimePreviousBookingDouble = 30;
            if (configTimePreviousBooking != null)
            {
                configTimePreviousBookingDouble = double.Parse(configTimePreviousBooking.Value);
            }
            if (DateTime.Now < existingReservation.BookingTime.AddMinutes(-configTimePreviousBookingDouble))
            {
                throw new BusinessException($"Bạn không thể sắp xếp bàn cho việc đặt bàn trước quá {configTimePreviousBookingDouble.ToString()} phút");
            }
            foreach (var table in existingTables)
            {
                var tableAssignReservation = await _tableAssignReservationRepository.GetSingleAsync(x => x.ReservationId == reservationId
                    && x.TableId == table.Id);
                if (tableAssignReservation != null)
                {
                    table.SetClosing();
                    table.SetNullCurrentReservationId();
                    _tableRepository.Update(table);
                    _tableAssignReservationRepository.HardDelete(tableAssignReservation);
                }
            }
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
        public async Task<bool> CheckInAsync(Guid reservationId)
        {
            var existingReservation = await _bookingRepository.GetSingleByIdAsync(reservationId, "TableAssignReservations");
            if (existingReservation == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            }
            if (existingReservation.BookingStatus == ReservationStatusEnum.Cancelled)
            {
                throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.INVALID_BOOKING_STATUS);
            }
            var listTableIds = existingReservation.TableAssignReservations.Select(x => x.TableId).ToList();
            var existingTables = await _tableRepository.GetListAsTracking(x => listTableIds.Contains(x.Id)).ToListAsync();
            if (existingTables == null || !existingTables.Any())
            {
                return false;
            }
            foreach (var table in existingTables)
            {
                table.SetOpening();
                table.SetNullCurrentReservationId();
                _tableRepository.Update(table);
            }
            existingReservation.Checkedin();
            _bookingRepository.Update(existingReservation);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }

        public async Task ConfirmAsync(Guid reservationId)
        {
            var existingReservation = await _bookingRepository.GetSingleByIdAsync(reservationId);
            if (existingReservation == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            }
            existingReservation.Confirm();
            _bookingRepository.Update(existingReservation);
            await _unitOfWork.SaveChangeAsync();
            TimeSpan bookingDelay = existingReservation.BookingTime.AddMinutes(-30) - DateTime.Now;
            if (bookingDelay < TimeSpan.Zero)
            {
                bookingDelay = TimeSpan.Zero;
            }

            // Lập lịch job thoong baso
            string openRegisterJobId = _backgroundJobService.ScheduleJob<IRealTimeNotifier>(
                service => service.AssignReservationAsync(existingReservation),
                bookingDelay);
            existingReservation.SetAssignTableIobId(openRegisterJobId);
            await _unitOfWork.SaveChangeAsync();
        }
        public async Task CancelAsync(Guid reservationId)
        {
            var existingReservation = await _bookingRepository.GetSingleByIdAsync(reservationId);
            if (existingReservation == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            }
            existingReservation.Cancel();
            _bookingRepository.Update(existingReservation);
            await _unitOfWork.SaveChangeAsync();
        }


    }
}
