using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.CreateBooking;
using Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence.Repositories;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Persistence;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CreateReservationByAdmin
{
    public class CreateReservationByAdminCommandHandler : IRequestHandler<CreateReservationByAdminCommand, ResultDto<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBackgroundJobService _backgroundJobService;
        private readonly IReservationRepository _reservationRepository;
        private readonly IConfigRepository _configRepository;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IReservationService _bookingService;

        public CreateReservationByAdminCommandHandler(IMapper mapper, IReservationService bookingService,
            ICustomerRepository customerRepository, IConfigRepository configRepository,
            IReservationRepository reservationRepository,
            IBackgroundJobService backgroundJobService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _backgroundJobService = backgroundJobService;
            _reservationRepository = reservationRepository;
            _configRepository = configRepository;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _bookingService = bookingService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateReservationByAdminCommand request, CancellationToken cancellationToken)
        {

            var customer = await _customerRepository.GetSingleAsync(x => x.Phone == request.PhoneNumber);

            if (customer == null)
            {
                customer = new Customer(Guid.NewGuid(), request.CustomerName, request.PhoneNumber);
                _customerRepository.Add(customer);
            }
            var result = await _bookingService.CreateAsync(
                customerName: request.CustomerName,
                phoneNumber: request.PhoneNumber,
                bookingTime: request.BookingTime,
                numberOfPeople: request.NumberOfPeople,
                reservationStatusEnum: Domain.Enums.ReservationStatusEnum.Confirmed);
            var existingReservation = await _reservationRepository.GetSingleByIdAsync(result, "TableAssignReservations");
            var configTimePreviousBooking = await _configRepository.GetSingleAsync(x => x.ConfigType == ConfigType.BOOKING_DATE_PREVIOUS_NOTIFY);
            double configTimePreviousBookingDouble = 30;
            if (configTimePreviousBooking != null)
            {
                configTimePreviousBookingDouble = double.Parse(configTimePreviousBooking.Value);
            }
            TimeSpan bookingDelay = existingReservation.BookingTime.AddMinutes(-configTimePreviousBookingDouble) - DateTime.Now;
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
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
