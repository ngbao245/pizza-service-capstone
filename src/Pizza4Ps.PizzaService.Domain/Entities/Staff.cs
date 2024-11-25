using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Staff : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
