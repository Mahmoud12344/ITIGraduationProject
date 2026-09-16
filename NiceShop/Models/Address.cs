namespace NiceShop.Models;

public class Address
{
    public int Id { get; set; }
    public string Government { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Building { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public AddressType AddressType { get; set; }
    public bool IsDefault { get; set; }

    // was int before, changed to string so it can actually match Customer.Id (which is a string guid)
    public string CustomerId { get; set; } = string.Empty;
    public virtual Customer Customer { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}