using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace university_applications.Test;

public class UniversityIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
{
  private readonly HttpClient _client;

  public UniversityIntegrationTest(TestingWebAppFactory<Program> factory)
    => _client = factory.CreateClient();

  [Theory]
  [InlineData("Brazil", "federal")]
  [InlineData("Brazil", "acre")]

  public async Task ShouldFindAUniversityByCountryAndName(string country, string name)
  {
    var res = await _client.GetAsync($"university/{country}/{name}");
    res.StatusCode.Should().Be(HttpStatusCode.OK);
    var result = await res.Content.ReadFromJsonAsync<object>();
    result.Should().BeOfType<JsonElement>();
  }

  [Theory]
  [InlineData("Brazil")]
  [InlineData("Turkey")]
  // [InlineData("Poneilandia")]
  public async Task ShouldFindAUniversityByCountry(string country)
  {
    var res = await _client.GetAsync($"university/{country}");
    res.StatusCode.Should().Be(HttpStatusCode.OK);
    var result = await res.Content.ReadFromJsonAsync<object>();
    result.Should().BeOfType<JsonElement>();
  }
}
