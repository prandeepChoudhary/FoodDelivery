public class MenuCategory
{
    public Guid Id { get; private set; }
    public Guid RestaurantId { get; private set; }
    public string? Name { get; private set; }
    public int DisplayOrder { get; private set; }
}
