namespace NiceShop.ViewModels;

public class AuthVM {
   

    public UserRegistrationVM  Register { get; set; } = new();

    public string ActiveTab { get; set; } = "login";
}