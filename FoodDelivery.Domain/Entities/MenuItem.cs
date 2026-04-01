namespace FoodDelivery.Domain.Entities;

public class MenuItem
{
    public Guid Id { get; private set; }
    public Guid RestaurantId { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAvailable { get; private set; }
    public string? ImageUrl { get; private set; }
    public int PreparationTime { get; private set; } // in minutes
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // Navigation properties
    public Restaurant Restaurant { get; set; }
    public MenuCategory Category { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public MenuItem() { }

    public MenuItem(Guid restaurantId, Guid categoryId, string name, string description, 
        decimal price, int preparationTime, string? imageUrl = null)
    {
        Id = Guid.NewGuid();
        RestaurantId = restaurantId;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        Price = price;
        IsAvailable = true;
        ImageUrl = imageUrl;
        PreparationTime = preparationTime;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string name, string description, decimal price, int preparationTime, string? imageUrl = null)
    {
        Name = name;
        Description = description;
        Price = price;
        PreparationTime = preparationTime;
        if (!string.IsNullOrEmpty(imageUrl))
            ImageUrl = imageUrl;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ToggleAvailability()
    {
        IsAvailable = !IsAvailable;
        UpdatedAt = DateTime.UtcNow;
    }
}
