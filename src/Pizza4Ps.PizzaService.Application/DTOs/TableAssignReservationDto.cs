namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class TableAssignReservationDto
    {
        public Guid? TableId { get; set; }
        public TableDto Table { get; set; }
    }
}
