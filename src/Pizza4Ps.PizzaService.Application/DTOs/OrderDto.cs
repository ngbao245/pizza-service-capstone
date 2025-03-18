namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string? OrderCode { get; set; }
        public string TableCode { get; set; }
        public DateTime StartTime { get; set; } //bắt đầu tạo đơn
        public DateTime? EndTime { get; set; }
        public decimal? TotalPrice { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string? Phone { get; set; }

        public Guid TableId { get; set; }

        public virtual TableDto Table { get; set; }
        public virtual ICollection<AdditionalFeeDto> AdditionalFees { get; set; } = new List<AdditionalFeeDto>();
    }
}



