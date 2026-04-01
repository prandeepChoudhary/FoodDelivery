using FoodDelivery.Domain.Entities;
using FoodDelivery.Infrastructure.Repositories;

namespace FoodDelivery.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IRepository<User> _users;
    private IRepository<Address> _addresses;
    private IRepository<Restaurant> _restaurants;
    private IRepository<MenuCategory> _menuCategories;
    private IRepository<MenuItem> _menuItems;
    private IRepository<Order> _orders;
    private IRepository<OrderItem> _orderItems;
    private IRepository<Review> _reviews;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepository<User> Users => _users ??= new Repository<User>(_context);
    public IRepository<Address> Addresses => _addresses ??= new Repository<Address>(_context);
    public IRepository<Restaurant> Restaurants => _restaurants ??= new Repository<Restaurant>(_context);
    public IRepository<MenuCategory> MenuCategories => _menuCategories ??= new Repository<MenuCategory>(_context);
    public IRepository<MenuItem> MenuItems => _menuItems ??= new Repository<MenuItem>(_context);
    public IRepository<Order> Orders => _orders ??= new Repository<Order>(_context);
    public IRepository<OrderItem> OrderItems => _orderItems ??= new Repository<OrderItem>(_context);
    public IRepository<Review> Reviews => _reviews ??= new Repository<Review>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
