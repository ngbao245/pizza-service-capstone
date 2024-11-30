using Pizza4Ps.PizzaService.Domain.Abstractions.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions
{
    public abstract class EntityAuditBase<TKey> : EntityBase<TKey>, IEntityAuditBase<TKey>
    {
        public DateTimeOffset CreatedDate { get ; set ; }
        public DateTimeOffset? ModifiedDate { get ; set ; }
        public Guid? CreatedBy { get ; set ; }
        public Guid? ModifiedBy { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTimeOffset? DeletedAt { get ; set ; }
        public Guid? DeletedBy { get ; set ; }
    }
}
