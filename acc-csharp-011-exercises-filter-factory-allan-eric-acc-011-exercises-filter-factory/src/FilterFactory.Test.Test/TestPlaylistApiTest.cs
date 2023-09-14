using Microsoft.AspNetCore.Mvc.Testing;

namespace FilterFactory.Test.Test;

public class TestPlaylistApiTest
{
    WebApplicationFactory<Program> _factory = new WebApplicationFactory<Program>();

    [Trait("Category", "2 - Adicionou o filtro AddHeaderFilter nos endpoints")]
    [Theory]
    [InlineData("/api/playlist", "X-Action-Name", "GetPlaylists", true)]
    [InlineData("/api/playlist/1", "X-Action-Name", "GetPlaylist", true)]
    [InlineData("/api/track", "X-Action-Name", "GetTracks", true)]
    [InlineData("/api/track/1", "X-Action-Name", "GetTrack", true)]
    public async void GetEndpoints_ShouldContainHeaderTest(string endpoint, string headerName, string headerValue, bool isCorrect)
    {
        TestPlaylistApi instance = new(_factory);
        Func<Task> task = async () => instance.GetEndpoints_ShouldContainHeader(endpoint, headerName, headerValue);
        if (isCorrect)
        {
            await task.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
        }
        else
        {
            await task.Should().ThrowAsync<Xunit.Sdk.XunitException>();
        }
        await task.Should().NotThrowAsync<NotImplementedException>();
    }
}