using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using EShop.Models;

namespace EShop.Test.Test
{
    public class Req2
    {
        [Trait("Category", "2 - Crie as relações entre as entidades com FluentAPI")]
        [Fact(DisplayName = "Order deve ter a propriedade ClientIdentity para ser usada como chave estrangeira")]
        public void ClientShouldHaveIdentityProperty()
        {
            var propertyToCheck = typeof(Order).GetProperty("ClientIdentity");
            propertyToCheck.Should().NotBeNull();
            var propertyTypeName = propertyToCheck.PropertyType;
            propertyTypeName.Should().BeAssignableTo(typeof(int));
        }

        [Trait("Category", "2 - Crie as relações entre as entidades com FluentAPI")]
        [Fact(DisplayName = "Crie a relação entre Client e Order")]
        public void ShouldCreateClientAndOrderRelatioship()
        {
            var contextOptions = new DbContextOptionsBuilder<EShopContext>()
                .UseInMemoryDatabase("ShouldCreateClientAndOrderRelatioship")
                .Options;
            EShopContext testContext = new(contextOptions);
            DbSet<Order> set = testContext.Set<Order>();
            var fKey = set.EntityType.GetForeignKeys().Where(
                fk => fk.PrincipalEntityType.Name == "EShop.Models.Client" &&
                fk.Properties.Where(e => e.Name == "ClientIdentity").First() != null
            ).FirstOrDefault();
            fKey.Should().NotBeNull();
        }
    }
}
