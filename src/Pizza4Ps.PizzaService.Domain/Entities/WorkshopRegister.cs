using Microsoft.EntityFrameworkCore.Infrastructure;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class WorkshopRegister : EntityAuditBase<Guid>
    {
        public string CustomerPhone { get; set; }

        public string CustomerName { get; set; }
        
        public string CustomerEmail { get; set; }

        public Guid WorkshopId { get; set; }

        public decimal TotalFee { get; set; }

        public Workshop Workshop { get; set; }

        public string Code { get; set; }

        public WorkshopRegisterStatus WorkshopRegisterStatus { get; set; }
        
        public DateTime RegisteredAt { get; set; }

        public int TotalParticipant { get; set; }

        public Guid? TableId { get; set; }

        public string? TableCode { get; set; }

        public Table Table { get; set; }

        public Guid? OrderId { get; set; }

        public Order Order { get; set; }

        public ICollection<WorkshopPizzaRegister> WorkshopPizzaRegisters { get; set; }

        public WorkshopRegister()
        {
            
        }

        public WorkshopRegister(string customerName, string customerPhone, string customerEmail, Guid workshopId, DateTime registeredAt, int totalParticipant, string code, decimal totalFee)
        {
            Id = Guid.NewGuid();
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            CustomerEmail = customerEmail;
            Code = code;
            WorkshopId = workshopId;
            RegisteredAt = registeredAt;
            TotalParticipant = totalParticipant;
            WorkshopRegisterStatus = WorkshopRegisterStatus.Registered;
            TotalFee = totalFee;
        }

        public void AssignTableOrder(Guid tableId, Guid orderId)
        {
            TableId = tableId;
            OrderId = orderId;
        }

        public void CheckIn()
        {
            WorkshopRegisterStatus = WorkshopRegisterStatus.Attended;
        }
    }
}
