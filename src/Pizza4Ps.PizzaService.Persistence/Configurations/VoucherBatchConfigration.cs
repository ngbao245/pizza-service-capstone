using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class VoucherBatchConfigration : IEntityTypeConfiguration<VoucherBatch>
    {
        public void Configure(EntityTypeBuilder<VoucherBatch> builder)
        {
            builder.ToTable(TableNames.VoucherBatch);
            builder.HasKey(x => x.Id);
        }
    }
}
