using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NiceShop.ViewModels;

public class UserRegistrationVM {
    [Required(ErrorMessage = "  Enter First name")]
    [StringLength(50,MinimumLength = 3 ,ErrorMessage ="name must be less than 50 characters and more than 3")]
    public string Fname { get; set; }
    [Required(ErrorMessage = " Enter Last name")]
    [StringLength(50,MinimumLength = 3 ,ErrorMessage ="name must be less than 50 characters and more than 3")]
    public string Lname { get; set; }
   
    [Required(ErrorMessage = "Enter Your Email Address ")]
    [EmailAddress(ErrorMessage = " Enter A Valid Email Address")]
    public string Email { get; set; }
   
    [Required(ErrorMessage = "Enter Your Phone Number")]
    [Phone(ErrorMessage = "Enter a valid Phone") ]
    public string Phone { get; set; }
 
    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character."
    )]
    public string Password{ get; set; }


    [Required(ErrorMessage = "Confirm Your Password")]
    [DataType((DataType.Password))]
    [Compare(nameof(Password),ErrorMessage =  "Passwords do not match.")]
    public string ConfirmPassword{ get; set; }
    
}