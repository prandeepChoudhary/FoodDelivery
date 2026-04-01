namespace FoodDelivery.Shared.DTOs;

public class RestaurantMenuDto
{
    public Guid RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public List<CategoryDto> Categories { get; set; } = new();
}