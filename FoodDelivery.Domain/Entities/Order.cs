namespace FoodDelivery.Domain.Entities;

using FoodDelivery.Domain.Enums;

public class Order
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid RestaurantId { get; private set; }
    public Guid? DeliveryAddressId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public OrderStatus Status { get; private set; }
    public string? SpecialInstructions { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeliveredAt { get; private set; }

    // Navigation properties
    public User User { get; set; }
    public Restaurant Restaurant { get; set; }
    public Address? DeliveryAddress { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public Order() { }

    public Order(Guid userId, Guid restaurantId, Guid? deliveryAddressId, 
        decimal totalAmount, string? specialInstructions = null)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        RestaurantId = restaurantId;
        DeliveryAddressId = deliveryAddressId;
        TotalAmount = totalAmount;
        Status = OrderStatus.Placed;
        SpecialInstructions = specialInstructions;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateStatus(OrderStatus status)
    {
        Status = status;
        UpdatedAt = DateTime.UtcNow;

        if (status == OrderStatus.Delivered)
            DeliveredAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        if (Status is OrderStatus.Preparing or OrderStatus.OutForDelivery or OrderStatus.Delivered)
            throw new InvalidOperationException("Cannot cancel order in current status");

        Status = OrderStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }
}
