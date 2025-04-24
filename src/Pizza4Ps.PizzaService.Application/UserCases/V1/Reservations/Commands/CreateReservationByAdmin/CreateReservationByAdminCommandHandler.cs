using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.CreateBooking;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CreateReservationByAdmin
{
    public class CreateReservationByAdminCommandHandler : IRequestHandler<CreateReservationByAdminCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IReservationService _bookingService;

        public CreateReservationByAdminCommandHandler(IMapper mapper, IReservationService bookingService,
            ICustomerRepository customerRepository)
        {
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
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
