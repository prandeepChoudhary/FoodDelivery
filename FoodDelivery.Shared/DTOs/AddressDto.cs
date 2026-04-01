namespace FoodDelivery.Shared.DTOs;

public class AddressDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Label { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public bool IsDefault { get; set; }
}
