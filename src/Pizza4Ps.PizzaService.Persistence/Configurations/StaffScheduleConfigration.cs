using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class StaffScheduleConfigration : IEntityTypeConfiguration<StaffSchedule>
    {
        public void Configure(EntityTypeBuilder<StaffSchedule> builder)
        {
            builder.ToTable(TableNames.StaffSchedule);
            builder.HasKey(x => x.Id);
        }
    }
}
