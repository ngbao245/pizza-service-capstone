using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class ProductComboSlotConfiguration : IEntityTypeConfiguration<ProductComboSlot>
    {
        public void Configure(EntityTypeBuilder<ProductComboSlot> builder)
        {
            builder.ToTable(TableNames.ProductComboSlot);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Combo)
                .WithMany(p => p.ProductComboSlots)
                .HasForeignKey(x => x.ComboId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
