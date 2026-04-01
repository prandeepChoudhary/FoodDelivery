using FoodDelivery.Shared.DTOs;

public interface IRestaurantService
{
    Task<List<RestaurantDto>> GetOpenRestaurantsAsync();
    Task<RestaurantMenuDto> GetRestaurantMenuAsync(Guid restaurantId);
}