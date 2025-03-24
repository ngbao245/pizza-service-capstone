using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class WorkshopRegisterConfiguration : IEntityTypeConfiguration<WorkshopRegister>
    {
        public void Configure(EntityTypeBuilder<WorkshopRegister> builder)
        {
            builder.ToTable(TableNames.WorkshopRegister);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Workshop)
                .WithMany(x => x.WorkshopRegisters)
                .HasForeignKey(x => x.WorkshopId);

            builder.HasOne(x => x.Table)
                .WithMany()
                .HasForeignKey(x => x.TableId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
