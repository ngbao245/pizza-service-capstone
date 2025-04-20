using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Option : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool SelectMany { get; set; }
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
        }

        public void UpdateOption(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}