using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using Moq;

using FilterFactory.Filters;

namespace FilterFactory.Test;

public class TestAddHeaderFilter
{
    [Theory]
    [MemberData(nameof(OnActionExecuting_ShouldRespondWithHeaderData))]
    public void OnActionExecuting_ShouldRespondWithHeader(AddHeaderFilter filterEntry, string headerExpected, string headerValueExpected)
    {

        var actionContext = new ActionContext(
            new DefaultHttpContext(),
            Mock.Of<RouteData>(),
            Mock.Of<ActionDescriptor>(),
            Mock.Of<ModelStateDictionary>()
        );

        var actionExecutingContext = new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                Mock.Of<Controller>()
        );

        // var actionFilter = filterEntry;
        filterEntry.OnActionExecuting(actionExecutingContext);

        actionExecutingContext.HttpContext.Response.Headers.ContainsKey(headerExpected).Should().BeTrue();
        actionExecutingContext.HttpContext.Response.Headers.Values.Should().Contain(headerValueExpected);

    }

    public static TheoryData<AddHeaderFilter, string, string> OnActionExecuting_ShouldRespondWithHeaderData = new(){
        {
            new AddHeaderFilter("X-Playlist-Name", "Playlist"),
            "X-Playlist-Name",
            "Playlist"
        }
    };
}
