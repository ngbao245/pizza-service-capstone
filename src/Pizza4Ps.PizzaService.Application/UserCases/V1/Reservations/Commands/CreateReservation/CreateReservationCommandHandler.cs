using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.CreateBooking
{
	public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ResultDto<Guid>>
	{
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
		private readonly IReservationService _bookingService;

		public CreateReservationCommandHandler(IMapper mapper, IReservationService bookingService,
			ICustomerRepository customerRepository)
		{
            _customerRepository = customerRepository;
            _mapper = mapper;
			_bookingService = bookingService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
		{
            // Nếu hợp lệ, tạo booking

            var customer = await _customerRepository.GetSingleAsync(x => x.Phone == request.PhoneNumber);

            if (customer == null)
            {
                throw new BusinessException("Không tìm thấy khách hàng");
            }
            //if (customer.PhoneOtp != request.PhoneOtp)
            //{
            //    throw new BusinessException("Phone OTP is not valid");
            //}
            var result = await _bookingService.CreateAsync(
				customerName: request.CustomerName,
				phoneNumber: request.PhoneNumber,
				bookingTime: request.BookingTime, 
				numberOfPeople: request.NumberOfPeople, 
				reservationStatusEnum: Domain.Enums.ReservationStatusEnum.Created);
			return new ResultDto<Guid>
			{
				Id = result
			};
		}
	}
}
