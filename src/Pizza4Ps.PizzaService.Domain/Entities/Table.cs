using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Table : EntityAuditBase<Guid>
    {
        public string Code { get; set; }
        public int Capacity { get; set; }
        public TableStatusEnum Status { get; set; }

        public Guid? CurrentOrderId { get; set; }
        public Guid? CurrentReservationId { get; set; }
        public Guid ZoneId { get; set; }

        public string? Note { get; set; }

        public Guid? TableMergeId { get; set; }

        public string? TableMergeName { get; set; }

        public TableMerge TableMerge { get; set; }

        public virtual Reservation CurrentReservation { get; set; }
        public virtual Order CurrentOrder { get; set; }
        public virtual Zone Zone { get; set; }

        private Table()
        {
        }

        public Table(Guid id, string code, int capacity, Guid zoneId)
        {
            Id = id;
            Code = code;
            Capacity = ValidateCapacity(capacity);
            SetClosing();
            ZoneId = zoneId;
        }

        private int ValidateCapacity(int capacity)
        {
            if (capacity <= 0)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.CAPACITY_INVALID);
            }
            return capacity;
        }

        public void SetCurrentOrderId(Guid currentOrderId)
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
        public void SetLocked(string? note)
        {
            Status = TableStatusEnum.Locked;
            Note = note;
        }
        public void SetBooked(Guid reservationId)
        {
            Status = TableStatusEnum.Reserved;
            CurrentReservationId = reservationId;
        }
        public void SetNullCurrentReservationId()
        {
            CurrentReservationId = null;
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
