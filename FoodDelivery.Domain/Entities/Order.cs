public class Order
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid RestaurantId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
