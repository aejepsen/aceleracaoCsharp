using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using FluentAssertions;

namespace auth_api.Test;

public class UserTest : IClassFixture<TestingWebAppFactory<Program>>
{
    public UserTest(TestingWebAppFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }
    private readonly HttpClient _client;

    [Fact]
    public async Task ShouldReturnUserData()
    {
        var clientJson = "{\"fullName\": \"name\",\"password\": \"password\",\"email\": \"name@name.com\" }";

        var resultPost = await _client.PostAsync("/user", new StringContent(clientJson, Encoding.UTF8, "application/json"));
        resultPost.StatusCode.Should().Be((System.Net.HttpStatusCode)200);
    }

    [Fact]
    public async Task ShouldReturnAllUsers()
    {
        await _client.DeleteAsync("/user");
        var resultGet = await _client.GetAsync("/user");
        resultGet.Should().BeSuccessful();

    }
}
