using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class TableDto
    {
        Guid Id { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public TableTypeEnum Status { get; set; } = TableTypeEnum.Closed;
        public Guid ZoneId { get; set; }

        public virtual ZoneDto Zone { get; set; }
    }
}
