using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffSchedule : EntityAuditBase<Guid>
    {
        public Guid StaffId { get; set; }
        public DateTimeOffset Date {  get; set; }
        public ConfigEnum Shift { get; set; }
    }
}
