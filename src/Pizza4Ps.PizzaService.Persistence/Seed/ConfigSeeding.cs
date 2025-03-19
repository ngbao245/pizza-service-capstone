using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Persistence.Seed
{
    public class ConfigSeeding : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.HasData(
                new Config
                {
                    Id = Guid.Parse("738eda23-9323-4db9-b36b-73adb8e942ef"),
                    ConfigType = ConfigType.VAT,
                    Key = "VAT",
                    Value = "0.08"
                },
                new Config
                {
                    Id = Guid.Parse("e0d7298b-5cd8-47e4-939c-e42e4e5a42e5"),
                    ConfigType = ConfigType.MAXIMUM_REGISTER_SLOT,
                    Key = "MAXIMUM_REGISTER_SLOT",
                    Value = "3"
                },
                new Config
                {
                    Id = Guid.Parse("b7c6da0c-f0de-44d7-9aa5-cb72eb569a9d"),
                    ConfigType = ConfigType.REGISTRATION_CUTOFF_DAY,
                    Key = "REGISTRATION_CUTOFF_DAY",
                    Value = "2"
                }
            );
        }
    }
}
