using FoodDelivery.Domain.Entities;
using FoodDelivery.Infrastructure.Repositories;

namespace FoodDelivery.Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Address> Addresses { get; }
    IRepository<Restaurant> Restaurants { get; }
    IRepository<MenuCategory> MenuCategories { get; }
    IRepository<MenuItem> MenuItems { get; }
    IRepository<Order> Orders { get; }
    IRepository<OrderItem> OrderItems { get; }
    IRepository<Review> Reviews { get; }

    Task<int> SaveChangesAsync();
}
