using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Table : EntityAuditBase<Guid>
    {
        public string Code { get; set; }
        public int Capacity { get; set; }
        public Guid ZoneId { get; set; }

        public TableStatusEnum Status { get; set; }
        public Guid? CurrentOrderId { get; set; }
        public virtual Order CurrentOrder { get; set; }

        public virtual Zone Zone { get; set; }

        private Table()
        {
        }

        public Table(Guid id, string code, int capacity, Guid zoneId)
        {
            Id = id;
            Code = code;
            Capacity = capacity;
            SetClosing();
            ZoneId = zoneId;
        }

        internal void SetCurrentOrderId(Guid currentOrderId)
        {
            CurrentOrderId = currentOrderId;
        }
        public void SetNullCurrentOrderId()
        {
            CurrentOrderId = null;
        }
        public void SetOpening()
        {
            Status = TableStatusEnum.Opening;
        }
        public void SetClosing()
        {
            Status = TableStatusEnum.Closing;
        }
        public void SetLocked()
        {
            Status = TableStatusEnum.Locked;
        }
        public void SetBooked()
        {
            Status = TableStatusEnum.Booked;
        }

        internal void UpdateTable(string code, int capacity, TableStatusEnum status, Guid zoneId)
        {
            Code = code;
            Capacity = capacity;
            Status = status;
            ZoneId = zoneId;
        }
    }
}
