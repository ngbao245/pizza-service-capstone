using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Category : EntityBase<Guid>
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
