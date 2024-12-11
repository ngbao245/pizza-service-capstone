namespace Pizza4Ps.PizzaService.Application.Abstractions
{
    public class PaginatedResultDto<T>
    {
        public List<T> Items { get; }
        public long TotalCount { get; }

        public PaginatedResultDto(List<T> items, long totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
    }
}
