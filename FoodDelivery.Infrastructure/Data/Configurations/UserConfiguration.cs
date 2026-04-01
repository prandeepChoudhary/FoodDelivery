using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodDelivery.Domain.Entities;
using FoodDelivery.Domain.Enums;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(x => x.PhoneNumber)
               .IsRequired()
               .HasMaxLength(15);

        builder.Property(x => x.PasswordHash)
               .IsRequired();

        builder.Property(x => x.Role)
               .IsRequired()
               .HasConversion<int>();

        builder.Property(x => x.IsActive)
               .IsRequired()
               .HasDefaultValue(true);

        builder.HasIndex(x => x.Email)
               .IsUnique();

        builder.HasIndex(x => x.PhoneNumber)
               .IsUnique();

        // Navigation properties
        builder.HasMany(x => x.Addresses)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Orders)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Reviews)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
