namespace FoodDelivery.Domain.Entities;

public class Address
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Label { get; private set; } // Home, Office, etc.
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }
    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }
    public bool IsDefault { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // Navigation property
    public User User { get; set; }

    public Address() { }

    public Address(Guid userId, string label, string street, string city, string state, 
        string postalCode, string country, decimal latitude, decimal longitude, bool isDefault = false)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Label = label;
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        Latitude = latitude;
        Longitude = longitude;
        IsDefault = isDefault;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string label, string street, string city, string state, 
        string postalCode, string country, decimal latitude, decimal longitude, bool isDefault)
    {
        Label = label;
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        Latitude = latitude;
        Longitude = longitude;
        IsDefault = isDefault;
        UpdatedAt = DateTime.UtcNow;
    }
}
