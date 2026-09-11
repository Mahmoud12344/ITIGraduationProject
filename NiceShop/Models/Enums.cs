namespace NiceShop.Models;

public enum OrderStatus {
    Pending,
    Confirmed,
    Shipped,
    Delivered,
    Cancelled
}

public enum AddressType {
    Home,
    Work
}

public enum ImageType {
    Thumbnail,
    Gallery,
    Banner,
    Product
}public enum SizeOption { XS, S, M, L, XL, XXL } // snapshot value stored on OrderItem at purchase time