namespace PopularLibraries.Test.Test;

public class ModelsTest
{
    [Trait("Category", "1 - Crie os modelos e context automaticamente a partir de PopularLibraries.db")]
    [Fact(DisplayName = "Database deve existir no namespace PopularLibraries.Models")]
    public void DatabaseShouldExists()
    {
        Type type = Type.GetType("PopularLibraries.Models.Database, PopularLibraries");
        type.Should().NotBeNull();
    }

    [Trait("Category", "1 - Crie os modelos e context automaticamente a partir de PopularLibraries.db")]
    [Fact(DisplayName = "Language deve existir no namespace PopularLibraries.Models")]
    public void LanguageShouldExists()
    {
        Type type = Type.GetType("PopularLibraries.Models.Language, PopularLibraries");
        type.Should().NotBeNull();
    }

    [Trait("Category", "1 - Crie os modelos e context automaticamente a partir de PopularLibraries.db")]
    [Fact(DisplayName = "Orm deve existir no namespace PopularLibraries.Models")]
    public void OrmShouldExists()
    {
        Type type = Type.GetType("PopularLibraries.Models.Orm, PopularLibraries");
        type.Should().NotBeNull();
    }

    [Trait("Category", "1 - Crie os modelos e context automaticamente a partir de PopularLibraries.db")]
    [Fact(DisplayName = "Provider deve existir no namespace PopularLibraries.Models")]
    public void ProviderShouldExists()
    {
        Type type = Type.GetType("PopularLibraries.Models.Provider, PopularLibraries");
        type.Should().NotBeNull();
    }

    [Trait("Category", "1 - Crie os modelos e context automaticamente a partir de PopularLibraries.db")]
    [Theory(DisplayName = "PopularLibrariesContext deve ser criada")]
    [InlineData("Databases")]
    [InlineData("Languages")]
    [InlineData("Orms")]
    [InlineData("Providers")]
    public void PopularLibrariesContextShouldHaveAttributeWithType(string attributeName)
    {
        Type type = Type.GetType("PopularLibraries.Models.PopularLibrariesContext, PopularLibraries");
        type.Should().NotBeNull();
        var propertyToCheck = type.GetProperty(attributeName);
        propertyToCheck.Should().NotBeNull();
    }
}
