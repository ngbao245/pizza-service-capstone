using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class WorkshopFoodDetailConfiguration : IEntityTypeConfiguration<WorkshopFoodDetail>
    {
        public void Configure(EntityTypeBuilder<WorkshopFoodDetail> builder)
        {
            builder.ToTable(TableNames.WorkshopFoodDetail);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Workshop)
                .WithMany()
                .HasForeignKey(x => x.WorkshopId);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);
        }
    }
}
