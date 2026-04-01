namespace FoodDelivery.Shared.DTOs;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public List<MenuItemDto> Items { get; set; } = new();
}