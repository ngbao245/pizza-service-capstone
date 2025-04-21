namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public string TableCode { get; set; }
        public string Name { get; set; }
        public string? Note { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime StartTime { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string OrderItemStatus { get; set; }
        public string Type { get; set; }
        //public virtual OrderDto Order { get; set; }
        public virtual ProductDto Product { get; set; }
        public string? ProductType { get; set; }
        public virtual ICollection<OrderItemDetailDto> OrderItemDetails { get; set; } = new List<OrderItemDetailDto>();
        public DateTime? StartTimeCooking { get; set; }
        public DateTime? StartTimeServing { get; set; }
        public DateTime? EndTime { get; set; }
        public string? ReasonCancel { get; set; }
        public bool IsProductCombo { get; set; }
        public Guid? ParentId { get; set; }
    }
}
