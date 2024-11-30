namespace Pizza4Ps.PizzaService.Domain.Abstractions.Entities
{
    public interface IUserTracking
    {
        Guid? CreatedBy { get; set; }
        Guid? ModifiedBy { get; set; }
        Guid? DeletedBy { get; set; }
    }
}
