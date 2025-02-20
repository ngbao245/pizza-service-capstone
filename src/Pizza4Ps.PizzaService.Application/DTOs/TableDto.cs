using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class TableDto
    {
        public Guid? Id { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public Guid ZoneId { get; set; }
        public Guid? CurrentOrderId { get; set; }

        public virtual Order CurrentOrder { get; set; }
        public virtual ZoneDto Zone { get; set; }
    }
}
