using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Option : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool SelectMany { get; set; }
        public OptionStatus OptionStatus { get; set; } 
        public virtual ICollection<OptionItem> OptionItems { get; set; } = new List<OptionItem>();

        public Option()
        {
        }

        public Option(Guid id, string name, string? description, bool selectMany)
        {
            Id = id;
            Name = name;
            Description = description;
            SelectMany = selectMany;
            OptionStatus = OptionStatus.Available;
        }

        public void UpdateOption(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public void UpdateStatus(OptionStatus status)
        {
            OptionStatus = status;
        }
    }
}