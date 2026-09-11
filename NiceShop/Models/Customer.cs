namespace NiceShop.Models;
public class Customer
{
    public string Id { get; set; }  
    public string FName { get; set; }
    public string LName { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; }
    public virtual Cart? Cart { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }
}