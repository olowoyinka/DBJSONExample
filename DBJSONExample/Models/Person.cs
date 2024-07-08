namespace DBJSONExample.Models;

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public int Age { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;
    
    public Wallet Wallets { get; set; }  = new Wallet();

    public List<Address> Addresses { get; set; } = new List<Address>();
    
    public Product Products { get; set; } = new Product();
}


public class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
}


public class Wallet
{
    public string Currency { get; set; } = string.Empty;

    public double Amount { get; set; }
}


public class Product
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<Order> Orders { get; set; }
}

public class Order
{
    public int Quantity { get; set; }

    public double Price { get; set; }

    public string Code { get; set; } = string.Empty;
}