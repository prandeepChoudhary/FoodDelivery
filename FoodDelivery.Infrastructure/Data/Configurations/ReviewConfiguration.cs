using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodDelivery.Domain.Entities;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("reviews");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Rating)
               .IsRequired();

        builder.Property(x => x.Comment)
               .HasMaxLength(1000);

        builder.HasIndex(x => x.OrderId);
        builder.HasIndex(x => x.RestaurantId);
        builder.HasIndex(x => x.UserId);

        // Foreign keys
        builder.HasOne(x => x.Order)
               .WithMany(x => x.Reviews)
               .HasForeignKey(x => x.OrderId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Restaurant)
               .WithMany(x => x.Reviews)
               .HasForeignKey(x => x.RestaurantId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
               .WithMany(x => x.Reviews)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
