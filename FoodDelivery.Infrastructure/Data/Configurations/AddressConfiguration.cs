using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodDelivery.Domain.Entities;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("addresses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Label)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(x => x.Street)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(x => x.City)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.State)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.PostalCode)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(x => x.Country)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Latitude)
               .HasColumnType("numeric(10,7)");

        builder.Property(x => x.Longitude)
               .HasColumnType("numeric(10,7)");

        builder.HasIndex(x => x.UserId);

        // Foreign key is configured in UserConfiguration
    }
}
