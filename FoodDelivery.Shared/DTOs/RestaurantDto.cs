namespace FoodDelivery.Shared.DTOs;

public class RestaurantDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Cuisine { get; set; }
    public decimal AverageRating { get; set; }
    public int TotalReviews { get; set; }
    public decimal DeliveryFee { get; set; }
    public int EstimatedDeliveryTime { get; set; }
    public bool IsOpen { get; set; }
    public string ImageUrl { get; set; }
}