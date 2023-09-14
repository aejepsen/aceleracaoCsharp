using code_first.Models;

namespace code_first
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new MarketContext())
            {
                db.Database.EnsureCreated();

                var category = new Category { Name = "Vinho" };
                db.Categories.Add(category);
                db.SaveChanges();
                var product = new Product { Name = "Sangue de Boi", Category = category };
                db.Products.Add(product);
                db.SaveChanges();

                /* var category = db.Categories.Find(2);
                db.Categories.Remove(category);
                db.SaveChanges(); */

            }
        }
    }
}

