using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class StaffZoneScheduleConfigration : IEntityTypeConfiguration<StaffZoneSchedule>
    {
        public void Configure(EntityTypeBuilder<StaffZoneSchedule> builder)
        {
            builder.ToTable(TableNames.StaffZoneSchedule);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Staff)
                .WithMany()
                .HasForeignKey(x => x.StaffId);

            builder.HasOne(x => x.Zone)
                .WithMany()
                .HasForeignKey(x => x.ZoneId);

            builder.HasOne(x => x.WorkingSlot)
                .WithMany()
                .HasForeignKey(x => x.WorkingSlotId);
        }
    }
}
