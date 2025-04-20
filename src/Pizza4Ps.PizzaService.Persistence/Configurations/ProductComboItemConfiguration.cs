using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class ProductComboItemConfiguration : IEntityTypeConfiguration<ProductComboItem>
    {
        public void Configure(EntityTypeBuilder<ProductComboItem> builder)
        {
            builder.ToTable(TableNames.ProductComboItem);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.HasOne(x => x.Combo)
                .WithMany(p => p.ComboItems)
                .HasForeignKey(x => x.ComboId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
