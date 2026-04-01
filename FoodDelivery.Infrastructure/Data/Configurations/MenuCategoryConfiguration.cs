using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodDelivery.Domain.Entities;

public class MenuCategoryConfiguration : IEntityTypeConfiguration<MenuCategory>
{
    public void Configure(EntityTypeBuilder<MenuCategory> builder)
    {
        builder.ToTable("menu_categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(x => x.DisplayOrder)
               .IsRequired();

        builder.HasIndex(x => new { x.RestaurantId, x.Name })
               .IsUnique();

        builder.HasIndex(x => x.RestaurantId);

        // Navigation
        builder.HasOne(x => x.Restaurant)
               .WithMany(x => x.MenuCategories)
               .HasForeignKey(x => x.RestaurantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Items)
               .WithOne(x => x.Category)
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
