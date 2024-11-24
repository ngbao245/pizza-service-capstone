using StructureCodeSolution.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderInTable : EntityAuditBase<Guid>
    {
        public Guid TableId { get; set; }
        public Guid OrderId { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        private OrderInTable()
        {
        }

        public OrderInTable(Guid id, Guid tableId, Guid orderId)
        {
            Id = id;
            TableId = tableId;
            OrderId = orderId;
        }
    }
}
