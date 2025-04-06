using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class WorkshopRegisterDto
    {
        public Guid Id { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerName { get; set; }

        public Guid WorkshopId { get; set; }

        public WorkshopDto Workshop { get; set; }

        public string WorkshopRegisterStatus { get; set; }

        public DateTime RegisteredAt { get; set; }

        public int TotalParticipant { get; set; }

        public Guid? OrderId { get; set; }

        public OrderDto Order { get; set; }

        public List<WorkshopPizzaRegisterDto> WorkshopPizzaRegisters { get; set; }

        public decimal TotalFee { get; set; }

        public string Code { get; set; }

        public Guid? TableId { get; set; }

        public string? TableCode { get; set; }

        public TableDto Table { get; set; }
    }
}
