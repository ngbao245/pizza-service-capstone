using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class SwapWorkingSlotDto
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public DateOnly WorkingDateFrom { get; set; }
        public string EmployeeFromName { get; set; }
        public Guid EmployeeFromId { get; set; }
        public Guid WorkingSlotFromId { get; set; }
        public DateOnly WorkingDateTo { get; set; }
        public string EmployeeToName { get; set; }
        public Guid EmployeeToId { get; set; }
        public Guid WorkingSlotToId { get; set; }
    }
}
