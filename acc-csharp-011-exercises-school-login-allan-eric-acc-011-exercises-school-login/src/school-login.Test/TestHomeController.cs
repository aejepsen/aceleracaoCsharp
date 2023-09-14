using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using SchoolLogin.Constants;
using SchoolLogin.Models;
using SchoolLogin.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;

namespace SchoolLogin.Test;

public class TestHomeController : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> _factory;

  public TestHomeController(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  [Theory(DisplayName = "Teste de endpoint que requer autorização com sucesso")]
  [InlineData("tulio.olivieri@betrybe.com", "Tulio123")]
  [InlineData("marina.novais@betrybe.com", "Marina123")]
  [InlineData("jaqueline.milsted@betrybe.com", "Jack123")]
  [InlineData("arthur.procopio@betrybe.com", "Arthur123")]
  public async Task TestHomePrivateSuccess(string email, string password)
  {
    var client = _factory.CreateClient();
    var student = new Student { Email = email, Password = password };
    var jsonBody = JsonConvert.SerializeObject(student);
    var body = new StringContent(jsonBody, Encoding.UTF8, "application/json");
    var result = await client.PostAsync("/Login", body);
    var token = result.Content.ReadAsStringAsync().Result;
    token.Should().NotBeNullOrEmpty();

    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    var response = await client.GetAsync("/Home");
    var resultForAuthorizeRoute = response.Content.ReadAsStringAsync().Result;
    resultForAuthorizeRoute.Should().Be("Parabéns, você realizou a autenticação com sucesso!");

  }

  [Theory(DisplayName = "Teste de endpoint que requer autorização com sucesso")]
  [InlineData("tulio.olivieri@betrybe.com", "tulio123")]
  [InlineData("marina.novais@betrybe.co", "Marina123")]
  [InlineData("jaqueline.milsted@betrybe.com", "Jack12")]
  [InlineData("arthurprocopio@betrybe.com", "Arhur123")]
  [InlineData("", "tulio123")]
  [InlineData("marina.novais@betrybe.co", "")]
  [InlineData("", "")]
  public async Task TestHomePrivateUnauthorizedFail(string email, string password)
  {
    var client = _factory.CreateClient();
    var student = new Student { Email = email, Password = password };
    var jsonBody = JsonConvert.SerializeObject(student);
    var body = new StringContent(jsonBody, Encoding.UTF8, "application/json");
    var result = await client.PostAsync("/Login", body);
    var token = result.Content.ReadAsStringAsync().Result;


    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    var response = await client.GetAsync("/Home");
    response.StatusCode.Should().Be((System.Net.HttpStatusCode)401);
  }

}
