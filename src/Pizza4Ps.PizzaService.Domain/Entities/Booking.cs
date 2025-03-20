using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class Booking : EntityAuditBase<Guid>
	{
        public Guid? CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BookingTime { get; set; } // Giờ khách hàng chọn đến
        public int NumberOfPeople { get; set; }
        public BookingStatusEnum BookingStatus { get; private set; }

        private Booking()
		{
		}

        public Booking(Guid? customerCode, string customerName, string phoneNumber, DateTime bookingTime, int numberOfPeople)
        {
            Id = Guid.NewGuid();
            CustomerCode = customerCode;
            CustomerName = customerName;
            PhoneNumber = phoneNumber;
            BookingTime = bookingTime;
            NumberOfPeople = numberOfPeople;
            BookingStatus = BookingStatusEnum.CheckedIn;
        }

        public void Cancel()
        {
            BookingStatus = BookingStatusEnum.Cancelled;
        }
	}
}
