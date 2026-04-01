namespace FoodDelivery.Shared.DTOs;

public class OrderDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid RestaurantId { get; set; }
    public Guid? DeliveryAddressId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public string SpecialInstructions { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public ICollection<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
}

public class OrderItemDto
{
    public Guid Id { get; set; }
    public Guid MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public MenuItemDto MenuItem { get; set; }
}
