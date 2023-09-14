using Microsoft.Data.Sqlite;

namespace code_first.Test.Test;

[Collection("Sequential")]
public class DbTest
{
    [Trait("Category", "3 - Crie o banco de dados")]
    [Fact]
    public void ProgramShouldCreateTablesAndInsertData()
    {
        var dataSource = Path.Combine(Environment.CurrentDirectory, "../../../../market.db");

        if (File.Exists(dataSource))
        {
            File.Delete(dataSource);
        }

        code_first.Program.Main(new string[] { });


        var connection = new SqliteConnection($"Data Source={dataSource}");

        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Categories;";

        var reader = command.ExecuteReader();

        var size = 0;
        while (reader.Read())
        {
            size++;
        }
        size.Should().BeGreaterThan(0);

        command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Products;";

        reader = command.ExecuteReader();

        size = 0;
        while (reader.Read())
        {
            size++;
        }
        size.Should().BeGreaterThan(0);
    }
}
