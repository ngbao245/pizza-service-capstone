using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class ProductComboSlotItemConfiguration : IEntityTypeConfiguration<ProductComboSlotItem>
    {
        public void Configure(EntityTypeBuilder<ProductComboSlotItem> builder)
        {
            builder.ToTable(TableNames.ProductComboSlotItem);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ProductComboSlot)
                .WithMany(p => p.ProductComboSlotItems)
                .HasForeignKey(x => x.ProductComboSlotId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
