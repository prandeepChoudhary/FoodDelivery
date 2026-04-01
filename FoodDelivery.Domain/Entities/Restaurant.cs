namespace FoodDelivery.Domain.Entities;

public class Restaurant
{
    public Guid Id { get; private set; }
    public Guid OwnerId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string Cuisine { get; private set; } // e.g., "Italian", "Indian", "Chinese"
    public decimal AverageRating { get; private set; }
    public int TotalReviews { get; private set; }
    public decimal DeliveryFee { get; private set; }
    public int EstimatedDeliveryTime { get; private set; } // in minutes
    public bool IsOpen { get; private set; }
    public string? ImageUrl { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // Navigation properties
    public ICollection<MenuCategory> MenuCategories { get; set; } = new List<MenuCategory>();
    public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public Restaurant() { }

    public Restaurant(Guid ownerId, string name, string description, string address, string city, 
        string cuisine, decimal deliveryFee, int estimatedDeliveryTime, string? imageUrl = null)
    {
        Id = Guid.NewGuid();
        OwnerId = ownerId;
        Name = name;
        Description = description;
        Address = address;
        City = city;
        Cuisine = cuisine;
        DeliveryFee = deliveryFee;
        EstimatedDeliveryTime = estimatedDeliveryTime;
        ImageUrl = imageUrl;
        IsOpen = true;
        AverageRating = 0;
        TotalReviews = 0;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string name, string description, string address, string city, string cuisine, 
        decimal deliveryFee, int estimatedDeliveryTime, string? imageUrl = null)
    {
        Name = name;
        Description = description;
        Address = address;
        City = city;
        Cuisine = cuisine;
        DeliveryFee = deliveryFee;
        EstimatedDeliveryTime = estimatedDeliveryTime;
        if (!string.IsNullOrEmpty(imageUrl))
            ImageUrl = imageUrl;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ToggleOpen()
    {
        IsOpen = !IsOpen;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateRating(decimal averageRating, int totalReviews)
    {
        AverageRating = averageRating;
        TotalReviews = totalReviews;
        UpdatedAt = DateTime.UtcNow;
    }
}