namespace Pizza4Ps.PizzaService.Application.Abstractions.Commands
{
    public class BaseDeleteCommand<Key>
    {
        public bool isHardDelete { get; set; } = false;
    }
}
