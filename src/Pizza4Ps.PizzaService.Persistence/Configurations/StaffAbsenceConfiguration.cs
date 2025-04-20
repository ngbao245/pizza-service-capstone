using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class StaffAbsenceConfiguration : IEntityTypeConfiguration<StaffAbsence>
    {
        public void Configure(EntityTypeBuilder<StaffAbsence> builder)
        {
            builder.ToTable(TableNames.StaffAbsence);
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
