namespace FoodDelivery.Domain.Entities;

public class Review
{
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid RestaurantId { get; private set; }
    public Guid UserId { get; private set; }
    public int Rating { get; private set; } // 1-5 stars
    public string Comment { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // Navigation properties
    public Order Order { get; set; }
    public Restaurant Restaurant { get; set; }
    public User User { get; set; }

    public Review() { }

    public Review(Guid orderId, Guid restaurantId, Guid userId, int rating, string comment)
    {
        if (rating < 1 || rating > 5)
            throw new ArgumentException("Rating must be between 1 and 5");

        Id = Guid.NewGuid();
        OrderId = orderId;
        RestaurantId = restaurantId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(int rating, string comment)
    {
        if (rating < 1 || rating > 5)
            throw new ArgumentException("Rating must be between 1 and 5");

        Rating = rating;
        Comment = comment;
        UpdatedAt = DateTime.UtcNow;
    }
}
