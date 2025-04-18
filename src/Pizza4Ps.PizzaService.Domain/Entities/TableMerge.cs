using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class TableMerge : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public Guid? TableMergeId { get; set; }

    }
}
