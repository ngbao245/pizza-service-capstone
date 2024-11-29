using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Table : EntityAuditBase<Guid>
    {
        public int TableNumber { get; set; }
        public int Capacity { get; set; }

        public TableTypeEnum Status { get; set; } = TableTypeEnum.Available;
        public Guid ZoneId { get; set; }

        public virtual Zone Zone { get; set; }
        public virtual ICollection<TableBooking> TableBookings { get; set; }
        public virtual ICollection<OrderInTable> OrdersInTable { get; set; }

        private Table()
        {
        }

        public Table(int tableNumber, int capacity, TableTypeEnum status, Guid zoneId)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            Status = status;
            ZoneId = zoneId;
        }
    }
}
