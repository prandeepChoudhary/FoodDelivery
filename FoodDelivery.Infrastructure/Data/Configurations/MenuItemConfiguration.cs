using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("menu_items");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Price)
               .HasColumnType("numeric(10,2)")
               .IsRequired();

        builder.Property(x => x.IsAvailable)
               .IsRequired();

        builder.HasIndex(x => new { x.RestaurantId, x.CategoryId });
    }
}
