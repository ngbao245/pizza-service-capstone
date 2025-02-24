namespace Pizza4Ps.PizzaService.Domain.Enums
{
    public enum OrderItemStatus
    {
        Pending, // đang chờ nấu
        Serving, // chờ phục vụ
        Done, // đã đem đến bàn
        Cancelled // hủy món
    }
}
