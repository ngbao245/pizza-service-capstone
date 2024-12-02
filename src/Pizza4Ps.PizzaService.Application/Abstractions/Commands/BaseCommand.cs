namespace Pizza4Ps.PizzaService.Application.Abstractions.BaseCommand
{
    public class BaseCommand<Key>
    {
        public Key Id { get; set; }
    }
}
