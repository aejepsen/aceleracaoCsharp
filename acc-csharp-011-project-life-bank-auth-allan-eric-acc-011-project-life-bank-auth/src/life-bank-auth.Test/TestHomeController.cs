
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LifeBankAuth.Test;

public class TestHomeController : IClassFixture<WebApplicationFactory<Program>>
{   
    private readonly WebApplicationFactory<Program> _factory;
    public TestHomeController(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Trait("Category", "2 - Criar Endpoint Anônimo")]
    [Fact(DisplayName = "Teste para MessageForEveryone com Status Ok")]    
    public async Task TestMessageForEveryoneSuccess()
    {   
        var response = await ApiGetRequest();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    public async Task<HttpResponseMessage> ApiGetRequest()
    {
        var client = _factory.CreateClient();
        return await client.GetAsync("/Home/MessageForEveryone");
    }
}