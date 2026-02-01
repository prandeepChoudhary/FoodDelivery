using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
               .IsRequired();

        builder.Property(x => x.CreatedAt)
               .IsRequired();

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.RestaurantId);
    }
}
