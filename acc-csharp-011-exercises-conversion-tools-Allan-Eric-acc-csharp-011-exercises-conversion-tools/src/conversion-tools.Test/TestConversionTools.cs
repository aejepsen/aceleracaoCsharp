using Xunit;
using FluentAssertions;
using conversion_tools;
using System;
using System.Threading;
using System.Globalization;

namespace conversion_tools.Test;

public class TestFirstRequirement{
    [Theory]
    [InlineData("4", 4)]
    [InlineData("66", 66)]
    [InlineData("-50", -50)]
    public void TestConvertStrToInt(string entry, int expected)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
        var convertStrToInt = new ConversionTools();
        var actual = convertStrToInt.ConvertStrToInt(entry);
        actual.Should().Be(expected);
    }
}

public class TestSecondRequirement{
    [Theory]
    [InlineData("4.0", 4.0)]
    [InlineData("66.1", 66.1)]
    [InlineData("-50.3", -50.3)]
    public void TestConvertStrToDouble(string entry, double expected)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
        var convertStrToDouble = new ConversionTools();
        var actual = convertStrToDouble.ConvertStrToDouble(entry);
        actual.Should().Be(expected);

    }
}

public class TestThirdRequirement{
    [Theory]
    [InlineData(4, "4")]
    [InlineData(66, "66")]
    [InlineData(-50, "-50")]
    public void TestConvertIntToStr(int entry, string expected)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
        var convertIntToStr = new ConversionTools();
        var actual = convertIntToStr.ConvertIntToStr(entry);
        actual.Should().Be(expected);
    }
}

public class TestFourthRequirement{
    [Theory]
    [InlineData(4.1, "4.1")]
    [InlineData(66.3, "66.3")]
    [InlineData(-50.1, "-50.1")]
    public void TestConvertDoubleToStr(double entry, string expected)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
        var convertDoubleToStr = new ConversionTools();
        var actual = convertDoubleToStr.ConvertDoubleToStr(entry);
        actual.Should().Be(expected);
    }
}