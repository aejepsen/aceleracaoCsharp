using System.Net.Http.Headers;
using MyWine.Models;
using MyWine.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace MyWine.Test;

public class TestAuthorizeMessageController : IClassFixture<WebApplicationFactory<Program>>
{

  private readonly WebApplicationFactory<Program> _factory;

  public TestAuthorizeMessageController(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  [Theory(DisplayName = "Teste para MessageForCustomOffer com Status OK")]
  [InlineData("Bahia", "Lover")]
  [InlineData("Bahia", "Specialist")]
  [InlineData("Ceará", "Lover")]
  [InlineData("Ceará", "Specialist")]
  [InlineData("Minas Gerais", "Lover")]
  [InlineData("Minas Gerais", "Specialist")]
  [InlineData("Roraima", "Lover")]
  [InlineData("Roraima", "Specialist")]
  public async Task TestMessageForCustomOfferSuccess(string state, string type)
  {

    // Arrange
    var user = new User { State = state, Lover = type };
    var token = new TokenGenerator().Generate(user);

    var newClient = _factory.CreateClient();
    newClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    // Act
    var result = await newClient.GetAsync("Notification/NotifyCustomCustomers");

    // Assert
    result.StatusCode.Should().Be((HttpStatusCode)200);
  }

  [Theory(DisplayName = "Teste para MessageForCustomOffer com Status Forbidden")]
  [InlineData("São Paulo", "Lover")]
  [InlineData("Rio de Janeiro", "Specialist")]
  [InlineData("Acre", "Specialist")]
  [InlineData("Ceará", "Basic")]
  [InlineData("Minas Gerais", "Basic")]
  [InlineData("Roraima", "Basic")]
  public async Task TestMessageForCustomOfferFail(string state, string type)
  {
    // Arrange
    var user = new User { State = state, Lover = type };
    var newClient = _factory.CreateClient();
    var token = new TokenGenerator().Generate(user);
    newClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    // Act
    var result = await newClient.GetAsync("Notification/NotifyCustomCustomers");
    
    result.StatusCode.Should().Be(HttpStatusCode.Forbidden);
  }

  [Theory(DisplayName = "Teste para MessageForCustomers com Status OK")]
  [InlineData("Bahia", "Lover")]
  [InlineData("Bahia", "Specialist")]
  [InlineData("Ceará", "Lover")]
  [InlineData("Ceará", "Specialist")]
  [InlineData("Minas Gerais", "Lover")]
  [InlineData("Minas Gerais", "Specialist")]
  [InlineData("Roraima", "Lover")]
  [InlineData("Roraima", "Specialist")]
  [InlineData("São Paulo", "Lover")]
  [InlineData("Rio de Janeiro", "Specialist")]
  [InlineData("Acre", "Specialist")]
  [InlineData("Ceará", "Basic")]
  [InlineData("Minas Gerais", "Basic")]
  [InlineData("Roraima", "Basic")]
  public async Task TestMessageForCustomersSuccess(string state, string type)
  {
    var user = new User { State = state, Lover = type };

    var newClient = _factory.CreateClient();
    var token = new TokenGenerator().Generate(user);
    newClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var result = await newClient.GetAsync("Notification/NotifyCustomers");
    result.StatusCode.Should().Be((HttpStatusCode)200);

  }

  [Theory(DisplayName = "Teste para MessageForCustomers com Status Unauthorized")]
  [InlineData("TOKENINVALIDO")]
  [InlineData("TRYBE")]
  [InlineData("123456789")]
  public async Task TestMessageForCustomersFail(string token)
  {
    // Arrange
    var newClient = _factory.CreateClient();
    newClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    // Act
    var result = await newClient.GetAsync("Notification/NotifyCustomers");
    // Assert
    result.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
  }

  [Fact(DisplayName = "Teste para MessageForEveryone com Status Ok")]
  public async Task TestMessageForEveryoneSuccess()
  {
    var newClient = _factory.CreateClient();
    var result = await newClient.GetAsync("Notification/NotifyEveryone");
    result.StatusCode.Should().Be((HttpStatusCode)200);
  }

}
