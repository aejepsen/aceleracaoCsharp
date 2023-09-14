using Microsoft.EntityFrameworkCore;

namespace code_first.Models
{
    public class MarketContext : DbContext

    {
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
        
        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options)
        {
        }

        public MarketContext(){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directorySufix;
                if (UnitTestDetector.IsRunningFromXUnit)
                {
                    directorySufix = "../../../../market.db";
                }
                else
                {
                    directorySufix = "../market.db";
                }
                var dataSource = Path.Combine(Environment.CurrentDirectory, directorySufix);
                optionsBuilder.UseSqlite($"Data Source={dataSource}");
            }
        }
    }
}
