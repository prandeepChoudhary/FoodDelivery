using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodDelivery.Domain.Entities;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("menu_items");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        builder.Property(x => x.Price)
               .HasColumnType("numeric(10,2)")
               .IsRequired();

        builder.Property(x => x.IsAvailable)
               .IsRequired()
               .HasDefaultValue(true);

        builder.Property(x => x.PreparationTime)
               .IsRequired();

        builder.HasIndex(x => new { x.RestaurantId, x.CategoryId });
        builder.HasIndex(x => x.RestaurantId);
        builder.HasIndex(x => x.CategoryId);

        // Navigation
        builder.HasOne(x => x.Restaurant)
               .WithMany(x => x.MenuItems)
               .HasForeignKey(x => x.RestaurantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Category)
               .WithMany(x => x.Items)
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.OrderItems)
               .WithOne(x => x.MenuItem)
               .HasForeignKey(x => x.MenuItemId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
