using Microsoft.AspNetCore.Mvc.Testing;

namespace FilterFactory.Test;

public class TestPlaylistApi : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public TestPlaylistApi(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("api/Track", "X-Action-Name", "GetTracks")]
    [InlineData("api/Track/1", "X-Action-Name", "GetTrack")]
    [InlineData("api/Playlist", "X-Action-Name", "GetPlaylists")]
    [InlineData("api/Playlist/1", "X-Action-Name", "GetPlaylist")]
    public async void GetEndpoints_ShouldContainHeader(string endpoint, string headerName, string headerValue)
    {

        var client = _factory.CreateClient();
        var res = await client.GetAsync(endpoint);
        // var ValueInHeader = res.Headers.GetValues(headerName);
        res.Headers.GetValues(headerName).Should().Contain(headerValue);

    }
}
