using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class TableMergeConfiguration : IEntityTypeConfiguration<TableMerge>
    {
        public void Configure(EntityTypeBuilder<TableMerge> builder)
        {
            builder.ToTable(TableNames.TableMerge);
            builder.HasKey(x => x.Id);

        }
    }
}
