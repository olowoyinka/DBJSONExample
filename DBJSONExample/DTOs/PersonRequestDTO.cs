namespace DBJSONExample.DTOs;

public class PersonRequestDTO
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public int Age { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public WalletRequestDTO Wallets { get; set; } = new WalletRequestDTO();

    public List<AddressRequestDTO> Addresses { get; set; } = new List<AddressRequestDTO>();

    public ProductRequestDTO Products { get; set; } = new ProductRequestDTO();
}


public class AddressRequestDTO
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
}


public class WalletRequestDTO
{
    public string Currency { get; set; } = string.Empty;

    public double Amount { get; set; }
}


public class ProductRequestDTO
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<OrderRequestDTO> Orders { get; set; }
}

public class OrderRequestDTO
{
    public int Quantity { get; set; }

    public double Price { get; set; }

    public string Code { get; set; } = string.Empty;
}