using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Persistence.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.ToTable(TableNames.ProductSize);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.Diameter)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            // Corrected relationship mapping
            builder.HasOne(ps => ps.Product)
                   .WithMany()
                   .HasForeignKey(ps => ps.ProductId);
        }
    }
}
