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
    public string? AssignTableJobId { get; set; }
    public ReservationPriorityStatus ReservationPriorityStatus { get; set; }
    public ReservationStatusEnum BookingStatus { get; private set; }

    public Guid? TableId { get; set; }
    public virtual Table? Table { get; set; }
    public virtual ICollection<TableAssignReservation> TableAssignReservations { get; set; }

    private Reservation() { }

    public Reservation(string customerName, string phoneNumber,
        DateTime bookingTime, int numberOfPeople, Guid? tableId, ReservationPriorityStatus reservationPriorityStatus, ReservationStatusEnum reservationStatusEnum)
    {
        Id = Guid.NewGuid();
        CustomerName = customerName;
        PhoneNumber = phoneNumber;
        BookingTime = bookingTime;
        NumberOfPeople = numberOfPeople;
        BookingStatus = reservationStatusEnum;
        TableId = tableId;
        ReservationPriorityStatus = reservationPriorityStatus;
    }

    public void Cancel()
    {
        BookingStatus = ReservationStatusEnum.Cancelled;
    }
    public void Checkedin()
    {
        BookingStatus = ReservationStatusEnum.Checkedin;
    }

    public void Confirm()
    {
        BookingStatus = ReservationStatusEnum.Confirmed;
    }
    public void SetAssignTableIobId(string assignTableJobId)
    {
        AssignTableJobId = assignTableJobId;
    }

    public void ChangeBookingTime(DateTime bookingTime)
    {
        BookingTime = bookingTime;
    }
}
