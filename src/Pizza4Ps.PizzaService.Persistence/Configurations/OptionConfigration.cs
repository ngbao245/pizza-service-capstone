using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class OptionConfigration : IEntityTypeConfiguration<Option>
	{
		public void Configure(EntityTypeBuilder<Option> builder)
		{
			builder.ToTable(TableNames.Option);
			builder.HasKey(x => x.Id);
		}
	}
}
