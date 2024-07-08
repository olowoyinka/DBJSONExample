using DBJSONExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DBJSONExample.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Person>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.OwnsOne(person => person.Wallets, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            });

            entity.OwnsMany(person => person.Addresses, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            });

            entity.OwnsOne(person => person.Products, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();

                ownedNavigationBuilder.OwnsMany(contactDetails => contactDetails.Orders);
            });
        });
    }
}