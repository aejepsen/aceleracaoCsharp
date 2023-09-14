using DateNow.Controllers;
using Xunit;
using FluentAssertions;

namespace DateNow.Test;

public class TestCurrentYearController
{
    [Theory]
    [InlineData(2023, true)]

    public void TestCurrentYearSuccess(int year, bool resultExpected)
    {
        var controller = new CurrentYearController();
        var result = controller.Get();
        result.Should().Be(2023);

    }
}
