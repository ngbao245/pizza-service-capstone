using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class ReasonConfig : EntityAuditBase<Guid>
    {
        public string Reason { get; set; }
        public ReasonConfigTypeEnum ReasonType { get; set; }

        public ReasonConfig()
        {
            
        }

        public ReasonConfig(string reason, ReasonConfigTypeEnum reasonType)
        {
            Reason = reason;
            ReasonType = reasonType;
        }
    }
}
