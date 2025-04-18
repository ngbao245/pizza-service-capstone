using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class TableMerge : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
    }
}
