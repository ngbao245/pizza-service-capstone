using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class TableDto
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public Guid ZoneId { get; set; }
        public Guid? CurrentOrderId { get; set; }

        public virtual Order CurrentOrder { get; set; }
        public virtual ZoneDto Zone { get; set; }
    }
}
