using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class WorkshopFoodDetail : EntityAuditBase<Guid>
    {
        public Guid WorkshopId { get; set; }

        public Workshop Workshop { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid? ProductId { get; set; }

        public Product Product { get; set; }

        public WorkshopFoodDetail()
        {
            
        }

        public WorkshopFoodDetail(Guid workshopId, Guid productId, string name, decimal price)
        {
            Id = Guid.NewGuid();
            WorkshopId = workshopId;
            ProductId = productId;
            Name = name;
            Price = price;
        }
    }
}
