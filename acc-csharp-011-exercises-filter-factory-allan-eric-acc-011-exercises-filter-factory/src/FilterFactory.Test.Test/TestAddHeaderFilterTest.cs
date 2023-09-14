using FilterFactory.Filters;
using FilterFactory.Test;

namespace FilterFactory.Test.Test;

public class TestAddHeaderFilterTest
{
    [Trait("Category", "1 - Deve criar o filtro AddHeaderFilter")]
    [Theory]
    [MemberData(nameof(OnActionExecuting_ShouldRespondWithHeaderData))]
    public void OnActionExecuting_ShouldRespondWithHeaderTest(AddHeaderFilter filterEntry, string headerExpected, string headerValueExpected, bool isCorrect)
    {
        TestAddHeaderFilter instance = new();
        Action act = () =>  instance.OnActionExecuting_ShouldRespondWithHeader(filterEntry, headerExpected, headerValueExpected);
        if (isCorrect)
        {
            act.Should().NotThrow<Xunit.Sdk.XunitException>();
        }
        else
        {
             act.Should().Throw<Xunit.Sdk.XunitException>();
        }

        act.Should().NotThrow<NotImplementedException>();
    }

    public static TheoryData<AddHeaderFilter, string, string, bool> OnActionExecuting_ShouldRespondWithHeaderData = new(){
        {
            new AddHeaderFilter("X-Playlist-Name", "Playlist"),
            "X-Playlist-Name",
            "Playlist",
            true
        },
        {
            new AddHeaderFilter("X-Playlist-Name", "Playlist"),
            "X-Playlist-Name",
            "Playlist",
            true
        },
        {
            new AddHeaderFilter("X-Playlist-Name1", "Playlist"),
            "X-Action-Name",
            "GetPlaylists",
            false
        },
        {
            new AddHeaderFilter("X-Playlist-Name", "Playlist1"),
            "X-Action-Name",
            "GetPlaylist",
            false
        }
    };
}
