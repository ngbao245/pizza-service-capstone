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
                    Value = "80",
                    Unit = "%"
                },
                new Config
                {
                    Id = Guid.Parse("e0d7298b-5cd8-47e4-939c-e42e4e5a42e5"),
                    ConfigType = ConfigType.MAXIMUM_REGISTER_SLOT,
                    Key = "MAXIMUM_REGISTER_SLOT",
                    Value = "3",
                    Unit = "Nhân viên"
                },
                new Config
                {
                    Id = Guid.Parse("b7c6da0c-f0de-44d7-9aa5-cb72eb569a9d"),
                    ConfigType = ConfigType.REGISTRATION_CUTOFF_DAY,
                    Key = "REGISTRATION_CUTOFF_DAY",
                    Value = "2",
                    Unit = "Ngày"
                },
                new Config
                {
                    Id = Guid.Parse("984394dd-9af3-401f-9319-0c5a7a3686fd"),
                    ConfigType = ConfigType.REGISTRATION_WEEK_LIMIT,
                    Key = "REGISTRATION_WEEK_LIMIT",
                    Value = "2",
                    Unit = "Tuần"
                },
                new Config
                {
                    Id = Guid.Parse("d2ee8501-1046-4895-bc33-cecbdb969f1b"),
                    ConfigType = ConfigType.SWAP_WORKING_SLOT_CUTOFF_DAY,
                    Key = "SWAP_WORKING_SLOT_CUTOFF_DAY",
                    Value = "2",
                    Unit = "Ngày"
                },
                new Config
                {
                    Id = Guid.Parse("37c23088-09b3-4f3d-8d56-e1183a899cca"),
                    ConfigType = ConfigType.MAXIMUM_REGISTER_PER_STAFF,
                    Key = "MAXIMUM_REGISTER_PER_STAFF",
                    Value = "3",
                    Unit = "Ca làm việc"
                }
            );
        }
    }
}
