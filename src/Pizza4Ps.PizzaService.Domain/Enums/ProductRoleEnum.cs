namespace Pizza4Ps.PizzaService.Domain.Enums
{
    public enum ProductRoleEnum
    {
        Single = 0, // Sản phẩm đơn lẻ
        Combo = 1,  // Sản phẩm combo
        Child = 2,  // Sản phẩm con thuộc combo
        Master = 3  // Sản phẩm cha (nếu cần thiết)
    }
}
