namespace FoodDelivery.Domain.Entities;

public class MenuCategory
{
    public Guid Id { get; private set; }
    public Guid RestaurantId { get; private set; }
    public string Name { get; private set; }
    public int DisplayOrder { get; private set; }
    public DateTime CreatedAt { get; private set; }

    // Navigation properties
    public Restaurant Restaurant { get; set; }
    public ICollection<MenuItem> Items { get; set; } = new List<MenuItem>();

    public MenuCategory() { }

    public MenuCategory(Guid restaurantId, string name, int displayOrder)
    {
        Id = Guid.NewGuid();
        RestaurantId = restaurantId;
        Name = name;
        DisplayOrder = displayOrder;
        CreatedAt = DateTime.UtcNow;
    }
}
