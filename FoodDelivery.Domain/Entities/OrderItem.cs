namespace FoodDelivery.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid MenuItemId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    // Navigation properties
    public Order Order { get; set; }
    public MenuItem MenuItem { get; set; }

    public OrderItem() { }

    public OrderItem(Guid orderId, Guid menuItemId, int quantity, decimal price)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        MenuItemId = menuItemId;
        Quantity = quantity;
        Price = price;
    }
}
