using System.ComponentModel.DataAnnotations;

namespace NiceShop.Models;
public class Review
{
    public int Id { get; set; }
    public bool IsApproved { get; set; }
    public bool IsVerifiedUser { get; set; }
    public DateTime Date { get; set; }
    public string Content { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    public string CustomerId { get; set; } // string since Customer.Id = ApplicationUser.Id (shared PK)
    public   Customer Customer { get; set; }

    public int ProductId { get; set; }
    public   Product Product { get; set; }
}