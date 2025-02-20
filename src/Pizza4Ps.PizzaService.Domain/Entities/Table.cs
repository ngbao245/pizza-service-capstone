using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class Table : EntityAuditBase<Guid>
	{
		public int TableNumber { get; set; }
		public int Capacity { get; set; }

		public Guid ZoneId { get; set; }

		public TableStatusEnum Status { get; set; }
        public Guid? CurrentOrderId { get; set; }
		public virtual Order CurrentOrder { get; set; }



		public virtual Zone Zone { get; set; }

		private Table()
		{
		}

		public Table(Guid id, int tableNumber, int capacity, TableStatusEnum status, Guid zoneId)
		{
			Id = id;
			TableNumber = tableNumber;
			Capacity = capacity;
			Status = status;
			ZoneId = zoneId;
		}

		internal void SetCurrentOrderId(Guid currentOrderId)
        {
            CurrentOrderId = currentOrderId;
        }

        internal void UpdateTable(int tableNumber, int capacity, TableStatusEnum status, Guid zoneId)
		{
			TableNumber = tableNumber;
			Capacity = capacity;
			Status = status;
			ZoneId = zoneId;
		}
	}
}
