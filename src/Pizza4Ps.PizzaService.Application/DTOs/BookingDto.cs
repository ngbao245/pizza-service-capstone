namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class BookingDto
    {
        public Guid? CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BookingTime { get; set; } // Giờ khách hàng chọn đến
        public int NumberOfPeople { get; set; }
        public string BookingStatus { get; private set; }
    }
}
