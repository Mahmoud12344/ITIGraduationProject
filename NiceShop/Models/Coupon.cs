namespace NiceShop.Models;

// temp class just so the code can run until dev3 create his own
public class Coupon
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public decimal Percentage { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}