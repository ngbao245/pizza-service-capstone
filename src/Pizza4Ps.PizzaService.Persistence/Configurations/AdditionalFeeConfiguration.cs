using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class AdditionalFeeConfiguration : IEntityTypeConfiguration<AdditionalFee>
    {
        public void Configure(EntityTypeBuilder<AdditionalFee> builder)
        {
            builder.ToTable(TableNames.AdditionalFee);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
