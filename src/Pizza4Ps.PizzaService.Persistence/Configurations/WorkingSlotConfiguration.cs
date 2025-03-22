using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class WorkingSlotConfiguration : IEntityTypeConfiguration<WorkingSlot>
    {
        public void Configure(EntityTypeBuilder<WorkingSlot> builder)
        {
            builder.ToTable(TableNames.WorkingSlot);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Day)
                .WithMany()
                .HasForeignKey(x => x.DayId);

            builder.HasOne(x => x.Shift)
                .WithMany()
                .HasForeignKey(x => x.ShiftId);
        }
    }
}
