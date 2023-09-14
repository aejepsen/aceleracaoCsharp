namespace random_meal.Test;

using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

public class RandomMealTest : IClassFixture<TestingWebAppFactory<Program>>
{
  private readonly HttpClient _client;
  public RandomMealTest(TestingWebAppFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ShouldMakeARequest()
  {
    var res = await _client.GetAsync("/meal");
    res.StatusCode.Should().Be(HttpStatusCode.OK);
    var result = await res.Content.ReadFromJsonAsync<object>();
    result.Should().BeOfType<JsonElement>();
  }
}