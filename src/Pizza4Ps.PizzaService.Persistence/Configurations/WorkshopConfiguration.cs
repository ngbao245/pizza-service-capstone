using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class WorkshopConfiguration : IEntityTypeConfiguration<Workshop>
    {
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            builder.ToTable(TableNames.Workshop);
            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.Zone)
                .WithMany()
                .HasForeignKey(x => x.ZoneId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
