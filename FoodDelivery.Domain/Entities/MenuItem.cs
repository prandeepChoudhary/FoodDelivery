public class MenuItem
{
    public Guid Id { get; private set; }
    public Guid RestaurantId { get; private set; }
    public Guid CategoryId { get; private set; }
    
    public string? Name { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAvailable { get; private set; }
}
