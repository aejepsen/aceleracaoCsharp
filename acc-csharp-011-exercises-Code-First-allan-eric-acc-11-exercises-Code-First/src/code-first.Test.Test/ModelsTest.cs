using Microsoft.EntityFrameworkCore;
using code_first.Models;

namespace code_first.Test.Test;

public class ModelsTest
{
    [Trait("Category", "1 - Faça o mapeamento das entidades")]
    [Theory(DisplayName = "Category deve os atributos corretos")]
    [InlineData("Name", typeof(string))]
    [InlineData("Products", typeof(IEnumerable<Product>))]
    public void CategoryShouldHaveAttributeWithType(string attributeName, Type attributeType)
    {
        var propertyToCheck = typeof(Category).GetProperty(attributeName);
        propertyToCheck.Should().NotBeNull();
        var propertyTypeName = propertyToCheck.PropertyType;
        propertyTypeName.Should().BeAssignableTo(attributeType);
    }

    [Trait("Category", "1 - Faça o mapeamento das entidades")]
    [Fact(DisplayName = "Category deve conter chave primária")]
    public void CategoryShouldContainPrimaryKey()
    {
        var contextOptions = new DbContextOptionsBuilder<MarketContextTest>()
            .UseInMemoryDatabase("CategoryShouldContainPrimaryKey")
            .Options;
        MarketContextTest testContext = new(contextOptions);
        DbSet<Category> set = testContext.Set<Category>();
        var pKey = set.EntityType.GetKeys().FirstOrDefault();
        pKey.Should().NotBeNull();
    }

    [Trait("Category", "1 - Faça o mapeamento das entidades")]
    [Fact(DisplayName = "Category deve conter uma propriedade de navegação para Products")]
    public void CategoryShouldContainNavigationProperty()
    {
        var contextOptions = new DbContextOptionsBuilder<MarketContextTest>()
            .UseInMemoryDatabase("CategoryShouldContainNavigationProperty")
            .Options;
        MarketContextTest testContext = new(contextOptions);
        DbSet<Category> set = testContext.Set<Category>();
        var navigationProperty = set.EntityType.GetNavigations().FirstOrDefault();
        navigationProperty.Should().NotBeNull();
        navigationProperty.Name.Should().Be("Products");
    }

    [Trait("Category", "1 - Faça o mapeamento das entidades")]
    [Theory(DisplayName = "Product deve os atributos corretos")]
    [InlineData("Name", typeof(string))]
    [InlineData("Category", typeof(Category))]
    public void ProductShouldHaveAttributeWithType(string attributeName, Type attributeType)
    {
        var propertyToCheck = typeof(Product).GetProperty(attributeName);
        propertyToCheck.Should().NotBeNull();
        var propertyTypeName = propertyToCheck.PropertyType;
        propertyTypeName.Should().BeAssignableTo(attributeType);
    }

    [Trait("Category", "1 - Faça o mapeamento das entidades")]
    [Fact(DisplayName = "Product deve conter chave primária")]
    public void ProductShouldContainPrimaryKey()
    {
        var contextOptions = new DbContextOptionsBuilder<MarketContextTest>()
            .UseInMemoryDatabase("ProductShouldContainPrimaryKey")
            .Options;
        MarketContextTest testContext = new(contextOptions);
        DbSet<Product> set = testContext.Set<Product>();
        var pKey = set.EntityType.GetKeys().FirstOrDefault();
        pKey.Should().NotBeNull();
    }

    [Trait("Category", "1 - Faça o mapeamento das entidades")]
    [Fact(DisplayName = "Product deve conter chave estrangeira para Category")]
    public void ProductShouldContainForeignKeyToCategory()
    {
        var contextOptions = new DbContextOptionsBuilder<MarketContextTest>()
            .UseInMemoryDatabase("ProductShouldContainForeignKeyToCategory")
            .Options;
        MarketContextTest testContext = new(contextOptions);
        DbSet<Product> set = testContext.Set<Product>();
        var fKey = set.EntityType.GetForeignKeys().Where(fk => fk.PrincipalEntityType.Name == "code_first.Models.Category" ).FirstOrDefault();
        fKey.Should().NotBeNull();
    }

    [Trait("Category", "1 - Faça o mapeamento das entidades")]
    [Fact(DisplayName = "Product deve conter uma propriedade de navegação para Category")]
    public void ProductShouldContainNavigationProperty()
    {
        var contextOptions = new DbContextOptionsBuilder<MarketContextTest>()
            .UseInMemoryDatabase("ProductShouldContainNavigationProperty")
            .Options;
        MarketContextTest testContext = new(contextOptions);
        DbSet<Product> set = testContext.Set<Product>();
        var navigationProperty = set.EntityType.GetNavigations().Where(nv => nv.TargetEntityType.Name == "code_first.Models.Category" ).FirstOrDefault();
        navigationProperty.Should().NotBeNull();
        navigationProperty.Name.Should().Be("Category");
    }
}
