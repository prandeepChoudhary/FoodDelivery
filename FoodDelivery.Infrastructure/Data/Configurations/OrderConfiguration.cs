using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodDelivery.Domain.Entities;
using FoodDelivery.Domain.Enums;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TotalAmount)
               .HasColumnType("numeric(12,2)")
               .IsRequired();

        builder.Property(x => x.Status)
               .IsRequired()
               .HasConversion<int>();

        builder.Property(x => x.SpecialInstructions)
               .HasMaxLength(500);

        builder.Property(x => x.CreatedAt)
               .IsRequired();

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.RestaurantId);
        builder.HasIndex(x => x.DeliveryAddressId);

        // Foreign keys and navigation
        builder.HasOne(x => x.User)
               .WithMany(x => x.Orders)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Restaurant)
               .WithMany(x => x.Orders)
               .HasForeignKey(x => x.RestaurantId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DeliveryAddress)
               .WithMany()
               .HasForeignKey(x => x.DeliveryAddressId)
               .OnDelete(DeleteBehavior.SetNull)
               .IsRequired(false);

        builder.HasMany(x => x.Items)
               .WithOne(x => x.Order)
               .HasForeignKey(x => x.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Reviews)
               .WithOne(x => x.Order)
               .HasForeignKey(x => x.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
