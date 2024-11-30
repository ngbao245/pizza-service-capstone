using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Seed
{
    public class ProductSeeding : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.HasData(

            //);
        }
    }
}
