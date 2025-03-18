using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class WorkshopPizzaRegisterConfiguration : IEntityTypeConfiguration<WorkshopPizzaRegister>
    {
        public void Configure(EntityTypeBuilder<WorkshopPizzaRegister> builder)
        {
            builder.ToTable(TableNames.WorkshopPizzaRegister);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.WorkshopRegister)
                .WithMany()
                .HasForeignKey(x => x.WorkshopRegisterId);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);

        }
    }
}
