using System.Text;
using Newtonsoft.Json;
using SchoolLogin.Constants;
using SchoolLogin.Models;
using SchoolLogin.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;

namespace SchoolLogin.Test;

public class TestLoginController : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> _factory;

  public TestLoginController(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }


  [Theory(DisplayName = "Teste para login de pessoa com Status OK")]
  [InlineData("tulio.olivieri@betrybe.com", "Tulio123")]
  [InlineData("marina.novais@betrybe.com", "Marina123")]
  [InlineData("jaqueline.milsted@betrybe.com", "Jack123")]
  [InlineData("arthur.procopio@betrybe.com", "Arthur123")]
  public async Task TestLoginSuccess(string email, string password)
  {
    var client = _factory.CreateClient();
    var student = new Student { Email = email, Password = password };
    var jsonBody = JsonConvert.SerializeObject(student);
    var body = new StringContent(jsonBody, Encoding.UTF8, "application/json");
    var result = await client.PostAsync("/Login", body);
    result.StatusCode.Should().Be((System.Net.HttpStatusCode)200);
    result.Should().NotBeNull();
  }

  [Theory(DisplayName = "Teste para login de pessoa com Status Not Found")]
  [InlineData("tulio.olivieri@betrybe.com", "tulio123")]
  [InlineData("marina.novais@betrybe.co", "Marina123")]
  [InlineData("jaqueline.milsted@betrybe.com", "Jack12")]
  [InlineData("arthurprocopio@betrybe.com", "Arhur123")]
  public async Task TestLoginNotFoundFail(string email, string password)
  {
    var client = _factory.CreateClient();
    var student = new Student { Email = email, Password = password };
    var jsonBody = JsonConvert.SerializeObject(student);
    var body = new StringContent(jsonBody, Encoding.UTF8, "application/json");
    var result = await client.PostAsync("/Login", body);
    result.StatusCode.Should().Be((System.Net.HttpStatusCode)404);
  }

  [Theory(DisplayName = "Teste para login de pessoa com Status Bad Request")]
  [InlineData("", "tulio123")]
  [InlineData("marina.novais@betrybe.co", "")]
  [InlineData("", "")]
  public async Task TestLoginBadRequestFail(string email, string password)
  {
    var client = _factory.CreateClient();
    var student = new Student { Email = email, Password = password };
    var jsonBody = JsonConvert.SerializeObject(student);
    var body = new StringContent(jsonBody, Encoding.UTF8, "application/json");
    var result = await client.PostAsync("/Login", body);
    result.StatusCode.Should().Be((System.Net.HttpStatusCode)400);
  }

}
