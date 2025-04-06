using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class ReasonConfigConfiguration : IEntityTypeConfiguration<ReasonConfig>
    {
        public void Configure(EntityTypeBuilder<ReasonConfig> builder)
        {
            builder.ToTable(TableNames.ReasonConfig);
            builder.HasKey(x => x.Id);

        }
    }
}
