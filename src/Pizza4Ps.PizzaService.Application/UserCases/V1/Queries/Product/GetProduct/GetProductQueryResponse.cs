namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Queries.Product.GetProduct
{
    public class GetProductQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
