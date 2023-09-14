using Microsoft.EntityFrameworkCore;
using EShop.Models;

namespace EShop.Test;
public class EShopTestContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }

    public EShopTestContext(DbContextOptions<EShopTestContext> options)
        : base(options)
    {
    }
}
