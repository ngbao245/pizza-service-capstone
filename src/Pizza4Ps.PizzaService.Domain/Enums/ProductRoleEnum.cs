namespace Pizza4Ps.PizzaService.Domain.Enums
{
    public enum ProductRoleEnum
    {
        Master = 0, // Sản phẩm cha
        Child = 1,  // Sản phẩm con thuộc combo
        Combo = 2,  // Sản phẩm combo
    }
}
