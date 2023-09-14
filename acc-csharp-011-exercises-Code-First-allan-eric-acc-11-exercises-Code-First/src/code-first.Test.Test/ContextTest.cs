using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using code_first.Models;

namespace code_first.Test.Test;

[Collection("Sequential")]
public class ContextTest
{
    [Trait("Category", "2 - Configure o Contexto")]
    [Fact]
    public void ContextShouldBeAbleToCreateData()
    {
        using(var ctx = new MarketContext())
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var category = new Category() { Name = "Alimentos" };
            var prod = new Product() { Name = "Cookie", CategoryId = 1 };

            ctx.Categories.Add(category);
            ctx.Products.Add(prod);
            ctx.SaveChanges();
        }

        var dataSource = Path.Combine(Environment.CurrentDirectory, "../../../../market.db");

        var connection = new SqliteConnection($"Data Source={dataSource}");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Name FROM Categories;";

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var name = reader.GetString(0);

            name.Should().Be("Alimentos");
        }

        command = connection.CreateCommand();
        command.CommandText = "SELECT Name, CategoryId FROM Products;";

        reader = command.ExecuteReader();

        while (reader.Read())
        {
            var name = reader.GetString(0);
            var categoryId = reader.GetString(1);

            name.Should().Be("Cookie");
            categoryId.Should().Be("1");
        }
    }
}
