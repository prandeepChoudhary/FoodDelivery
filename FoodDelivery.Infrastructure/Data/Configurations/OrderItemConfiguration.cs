using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    }
}
