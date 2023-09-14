using Xunit;
using FluentAssertions;
using System;

namespace month_name.Test;

public class TestMonthNameInCalendar
{
    [Theory]
    [InlineData(1, "Janeiro")]
    public void TestMonthNameInCalendarSucess(int month, string expected)
    {
        var result = MonthNameInCalendar.MonthName(month);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, "inválido")]
    public void TestMonthNameInCalendarOutOfRange(int month, string expected)
    {
        var result = MonthNameInCalendar.MonthName(month);
        result.Should().Be(expected);
    }
}