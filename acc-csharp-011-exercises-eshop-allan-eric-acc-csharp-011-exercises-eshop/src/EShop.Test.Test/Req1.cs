using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using EShop.Models;

namespace EShop.Test.Test;
public class Req1
{
    [Trait("Category", "1 - Defina as chaves das entidades com FluentAPI")]
    [Fact(DisplayName = "Client deve ter a propriedade ClientIdentity")]
    public void ClientShouldHaveIdentityProperty()
    {
        var propertyToCheck = typeof(Client).GetProperty("ClientIdentity");
        propertyToCheck.Should().NotBeNull();
        var propertyTypeName = propertyToCheck.PropertyType;
        propertyTypeName.Should().BeAssignableTo(typeof(int));
    }

    [Trait("Category", "1 - Defina as chaves das entidades com FluentAPI")]
    [Fact(DisplayName = "Client deve conter a chave primária ClientIdentity criada com FluentAPI")]
    public void CategoryShouldHavePrimaryKey()
    {
        // Test if exists the primary key
        var contextOptions = new DbContextOptionsBuilder<EShopContext>()
            .UseInMemoryDatabase("ClientShouldHavePrimaryKey")
            .Options;
        EShopContext testContext = new(contextOptions);
        DbSet<Client> set = testContext.Set<Client>();
        var pKey = set.EntityType.GetKeys().Where(
            p => p.Properties.Where(e => e.Name == "ClientIdentity").First() != null
        ).FirstOrDefault();
        pKey.Should().NotBeNull();

        // Test if the primary key was created with FluentAPI
        var contextOptionsTest = new DbContextOptionsBuilder<EShopTestContext>()
            .UseInMemoryDatabase("CategoryShouldNotHavePrimaryKeyWithTestContext")
            .Options;
        EShopTestContext testContextTest = new(contextOptionsTest);
        Action act = () => {
            DbSet<Client> set = testContextTest.Set<Client>();
        };
        act.Should().Throw<InvalidOperationException>();
    }
}
