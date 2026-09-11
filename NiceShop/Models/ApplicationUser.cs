using Microsoft.AspNetCore.Identity;

namespace NiceShop.Models;

public class ApplicationUser : IdentityUser
{
    // Id, UserName, Email, PasswordHash, PhoneNumber,   already come from IdentityUser

    public int? ImageId { get; set; }
    public virtual Image? Image { get; set; }

    public virtual Customer? Customer { get; set; } 
    
}