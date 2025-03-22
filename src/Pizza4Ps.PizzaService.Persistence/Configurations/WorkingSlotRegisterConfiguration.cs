using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class WorkingSlotRegisterConfiguration : IEntityTypeConfiguration<WorkingSlotRegister>
    {
        public void Configure(EntityTypeBuilder<WorkingSlotRegister> builder)
        {
            builder.ToTable(TableNames.WorkingSlotRegister);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Staff)
                .WithMany()
                .HasForeignKey(x => x.StaffId);

            builder.HasOne(x => x.WorkingSlot)
                .WithMany()
                .HasForeignKey(x => x.WorkingSlotId);
        }
    }
}

