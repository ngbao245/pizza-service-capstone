namespace Pizza4Ps.PizzaService.Application.Models
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; }
        public int TotalCount { get; }

        public PaginatedResult(List<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
    }
}
