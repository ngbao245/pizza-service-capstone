using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderItem : EntityAuditBase<Guid>
    {
        public int OrderNumber { get; set; }
        public virtual ICollection<OrderItemTopping> Toppings { get; set; }
        public Guid MenuItemId { get; set; }
        
        public virtual MenuItem MenuItem { get; set; }
        private OrderItem() { }
        public OrderItem(Guid id, int orderNumber, Guid menuitemid) {   
            Id = id;
            OrderNumber = orderNumber;
            MenuItemId = menuitemid;
        }
    }
}
