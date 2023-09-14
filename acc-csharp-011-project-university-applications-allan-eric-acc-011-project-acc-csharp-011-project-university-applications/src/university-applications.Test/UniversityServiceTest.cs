using System.Text.Json;
using Moq;
using university_applications.Services;

namespace university_applications.Test;

public class UniversityServiceTest
{

  [Fact]
  public async Task ShouldReturnUniversityByCountryAndName()
  {
    var res = await new UniversityService(new Mock<HttpClient>().Object).FindUniversity("middle", "turkey");
    res.Should().BeOfType<JsonElement>();
    res.ToString().ToLower().Should().Contain("turkey");
    res.ToString().ToLower().Should().Contain("middle");

  }

  [Fact]

  public async Task ShouldReturnAUniversityByCountry()
  {
    var res = await new UniversityService(new Mock<HttpClient>().Object).FindUniversity("turkey");
    res.Should().BeOfType<JsonElement>();
    res.ToString().ToLower().Should().Contain("turkey");

  }
}
