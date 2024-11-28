using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffZone : EntityAuditBase<Guid>
    {
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }

        public StaffZone()
        {
        }

        public StaffZone(Guid staffId, Guid zoneId)
        {
            StaffId = staffId;
            ZoneId = zoneId;
        }
    }
}