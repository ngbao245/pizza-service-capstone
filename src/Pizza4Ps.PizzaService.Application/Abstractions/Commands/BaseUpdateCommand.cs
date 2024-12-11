namespace Pizza4Ps.PizzaService.Application.Abstractions.Commands
{
    public class BaseUpdateCommand<Key>
    {
        public Key Id { get; set; }
    }
}
