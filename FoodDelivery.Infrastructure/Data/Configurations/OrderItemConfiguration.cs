using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodDelivery.Domain.Entities;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("order_items");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
               .IsRequired();

        builder.Property(x => x.Price)
               .HasColumnType("numeric(10,2)")
               .IsRequired();

        builder.HasIndex(x => x.OrderId);
        builder.HasIndex(x => x.MenuItemId);

        // Navigation
        builder.HasOne(x => x.Order)
               .WithMany(x => x.Items)
               .HasForeignKey(x => x.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.MenuItem)
               .WithMany(x => x.OrderItems)
               .HasForeignKey(x => x.MenuItemId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
