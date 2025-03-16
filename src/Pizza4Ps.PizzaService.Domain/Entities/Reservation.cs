using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

public class Reservation : EntityAuditBase<Guid>
{
    public Guid? CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BookingTime { get; set; }
    public int NumberOfPeople { get; set; }
    public ReservationStatusEnum BookingStatus { get; private set; }

    public Guid? TableId { get; set; }
    public virtual Table? Table { get; set; }

    private Reservation() { }

    public Reservation(Guid? customerId, string customerName, string phoneNumber, DateTime bookingTime, int numberOfPeople, Guid? tableId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        CustomerName = customerName;
        PhoneNumber = phoneNumber;
        BookingTime = bookingTime;
        NumberOfPeople = numberOfPeople;
        BookingStatus = ReservationStatusEnum.Created;
        TableId = tableId;
    }

    public void Cancel()
    {
        BookingStatus = ReservationStatusEnum.Cancelled;
    }
    public void Checkedin()
    {
        BookingStatus = ReservationStatusEnum.Checkedin;
    }
}
