using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderInTable : EntityAuditBase<Guid>
    {
        public string? Status { get; set; }
        public Guid TableId { get; set; }

        public virtual Table Table { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        private OrderInTable()
        {
        }

        public OrderInTable(string? status, Guid tableId)
        {
            Status = status;
            TableId = tableId;
        }
    }
}
