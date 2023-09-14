using FluentAssertions;

namespace AzureDeploy.Test.Test;

public class TestTestDomainName
{
    [Trait("Category", "2 - Faça Deploy da aplicação na Azure")]
    [Fact(DisplayName = "A URL deve conter azurewebsites")]
    public void TestSuccessTestDomainName()
    {
        const string azureDomain = "azurewebsites";
        var url = Helper.GetURLFromFile();
        var splitedUrl = url.Split(".");
        splitedUrl[1].Should().Be(azureDomain);
    }
}