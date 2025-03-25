using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class SwapWorkingSlotDto
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public Guid EmployeeFromId { get; set; }
        public Guid EmployeeToId { get; set; }
        public Guid WorkingSlotFromId { get; set; }
        public Guid WorkingSlotToId { get; set; }
    }
}
