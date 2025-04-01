using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class SwapWorkingSlotConfiguration : IEntityTypeConfiguration<SwapWorkingSlot>
    {
        public void Configure(EntityTypeBuilder<SwapWorkingSlot> builder)
        {
            builder.ToTable(TableNames.SwapWorkingSlot);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.StaffFrom)
                   .WithMany()
                   .HasForeignKey(s => s.EmployeeFromId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.StaffTo)
                   .WithMany()
                   .HasForeignKey(s => s.EmployeeToId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.WorkingSlotFrom)
                   .WithMany()
                   .HasForeignKey(s => s.WorkingSlotFromId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.WorkingSlotTo)
                   .WithMany()
                   .HasForeignKey(s => s.WorkingSlotToId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
