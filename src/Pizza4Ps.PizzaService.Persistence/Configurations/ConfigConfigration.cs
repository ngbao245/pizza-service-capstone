using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class ConfigConfigration : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.ToTable(TableNames.Config);
            builder.HasKey(x => x.Id);
        }
    }
}
