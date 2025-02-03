using System.Reflection;

namespace Pizza4Ps.PizzaService.Infrastructure
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
