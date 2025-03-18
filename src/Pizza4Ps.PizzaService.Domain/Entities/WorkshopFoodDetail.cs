using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class WorkshopFoodDetail : EntityAuditBase<Guid>
    {
        public Guid WorkshopId { get; set; }

        public Workshop Workshop { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
