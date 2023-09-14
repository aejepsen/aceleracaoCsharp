using Microsoft.EntityFrameworkCore;

namespace code_first.Models
{
    public class MarketContextTest : DbContext
    {
        public MarketContextTest(DbContextOptions<MarketContextTest> options)
            : base(options)
        {
        }
        public MarketContextTest(){}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("MarketContextTest");
            }
        }
    }
}
