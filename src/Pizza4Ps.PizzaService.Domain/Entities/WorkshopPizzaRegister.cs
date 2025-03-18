using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class WorkshopPizzaRegister : EntityAuditBase<Guid>
    {
        public Guid WorkshopRegisterId { get; set; }

        public WorkshopRegister WorkshopRegister { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }    
        
        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<WorkshopPizzaRegisterDetail> WorkshopPizzaRegisterDetails { get; set; }

        public WorkshopPizzaRegister()
        {
            
        }

        public WorkshopPizzaRegister(Guid workshopRegisterId, Guid productId, decimal price, decimal totalPrice)
        {
            Id = Guid.NewGuid();
            WorkshopRegisterId = workshopRegisterId;
            ProductId = productId;
            Price = price;
            TotalPrice = totalPrice;
        }
    }
}
