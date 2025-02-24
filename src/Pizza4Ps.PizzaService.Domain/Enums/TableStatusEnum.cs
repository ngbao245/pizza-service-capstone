namespace Pizza4Ps.PizzaService.Domain.Enums
{
    public enum TableStatusEnum
    {
        Opening, // bàn mở sẵn sàng phục vụ
        Closing, // bàn đóng 
        Paid, // bàn đã thanh toán
        Booked, // bàn được đặt
        Locked // đã khóa
    }
}
