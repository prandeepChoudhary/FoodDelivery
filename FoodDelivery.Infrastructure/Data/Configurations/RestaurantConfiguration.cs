using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodDelivery.Domain.Entities;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.ToTable("restaurants");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.OwnerId)
               .IsRequired();

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Description)
               .HasMaxLength(1000);

        builder.Property(x => x.Address)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(x => x.City)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Cuisine)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.DeliveryFee)
               .HasColumnType("numeric(12,2)")
               .IsRequired();

        builder.Property(x => x.AverageRating)
               .HasColumnType("numeric(3,2)")
               .HasDefaultValue(0);

        builder.Property(x => x.IsOpen)
               .IsRequired()
               .HasDefaultValue(true);

        builder.HasIndex(x => x.OwnerId);
        builder.HasIndex(x => x.City);
        builder.HasIndex(x => x.Cuisine);

        // Navigation
        builder.HasMany(x => x.MenuCategories)
               .WithOne(x => x.Restaurant)
               .HasForeignKey(x => x.RestaurantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.MenuItems)
               .WithOne(x => x.Restaurant)
               .HasForeignKey(x => x.RestaurantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Orders)
               .WithOne(x => x.Restaurant)
               .HasForeignKey(x => x.RestaurantId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Reviews)
               .WithOne(x => x.Restaurant)
               .HasForeignKey(x => x.RestaurantId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
