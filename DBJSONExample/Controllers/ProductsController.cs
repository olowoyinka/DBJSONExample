using DBJSONExample.Data;
using DBJSONExample.DTOs;
using DBJSONExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBJSONExample.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct([FromQuery] string orderCode)
    {
        var result = await _context.People.Where(s => s.Products.Orders.Any(s => s.Code == orderCode)).ToListAsync();

        return Ok (result);
    }


    [HttpPost]
    public async Task<IActionResult> CreateProduct ([FromBody] PersonRequestDTO model)
    {
        var newPerson = new Person
        {
            Age = model.Age,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            Wallets = new Wallet
            {
                Amount = model.Wallets.Amount,
                Currency = model.Wallets.Currency
            },
            Addresses = model.Addresses.Select(s => new Address
            {
                City = s.City,
                IsDefault = s.IsDefault,
                State = s.State,
                Street = s.Street,
                Country = s.Country,
            }).ToList(),
            Products = new Product
            {
                Description = model.Products.Description,
                Name = model.Products.Name,
                Orders = model.Products.Orders.Select(f => new Order
                {
                    Code = f.Code,
                    Price = f.Price,
                    Quantity = f.Quantity,
                }).ToList()
            }
        };

        await _context.People.AddAsync(newPerson);
        await _context.SaveChangesAsync();

        return Ok("Created Successfully");
    }



    [HttpPost("bulk")]
    public async Task<IActionResult> CreateBulkProduct([FromBody] List<PersonRequestDTO> listmodel)
    {
        foreach (var model in listmodel)
        {
            var newPerson = new Person
            {
                Age = model.Age,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Wallets = new Wallet
                {
                    Amount = model.Wallets.Amount,
                    Currency = model.Wallets.Currency
                },
                Addresses = model.Addresses.Select(s => new Address
                {
                    City = s.City,
                    IsDefault = s.IsDefault,
                    State = s.State,
                    Street = s.Street,
                    Country = s.Country,
                }).ToList(),
                Products = new Product
                {
                    Description = model.Products.Description,
                    Name = model.Products.Name,
                    Orders = model.Products.Orders.Select(f => new Order
                    {
                        Code = f.Code,
                        Price = f.Price,
                        Quantity = f.Quantity,
                    }).ToList()
                }
            };

            await _context.People.AddAsync(newPerson);
        }

        await _context.SaveChangesAsync();

        return Ok("Created Successfully");
    }


    [HttpPatch("{Id}/orders/{code}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int Id, [FromRoute] string code, [FromBody] PersonUpdateDTO model)
    {
        var getPeoPle = await _context.People
                                      .Where(s => s.Id == Id)
                                      .FirstOrDefaultAsync();

        foreach (var item in getPeoPle.Products.Orders.Where(s => s.Code == code))
        {
            item.Price = model.price;
        }

        _context.People.Update(getPeoPle);
        await _context.SaveChangesAsync();

        return Ok("Updated Successfully");
    }
}