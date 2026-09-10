namespace NiceShop.Models;

public enum OrderStatus
{
    Pending,
    Confirmed,
    Shipped,
    Delivered,
    Cancelled
}

public enum AddressType
{
    Home,
    Work
}