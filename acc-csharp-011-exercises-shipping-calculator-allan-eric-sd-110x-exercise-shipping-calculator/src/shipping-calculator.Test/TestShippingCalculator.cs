using Xunit;
using FluentAssertions;
using System;

namespace ShippingCalculator.Test
{
    public class TestShippingCalculator
    {
        [Theory(DisplayName = "CalculateShipping retorna valores corretos cfe valores de entrada")]
        [InlineData(50, 25)]
        [InlineData(100, 20)]
        [InlineData(199, 15)]
        [InlineData(200, 0)]

        public void TestCalculateShippingSuccess(double orderPrice, int resultExpected)
        {
            var shippingCalculator = new ShippingCalculator();
            var result = shippingCalculator.CalculateShipping(orderPrice);
            result.Should().Be(resultExpected);
        }


        [Theory(DisplayName = "CalculateShipping retorna ArgumentException cfe valores de entrada")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]

        public void TestCalculateShippingException(double orderPrice)
        {
            var shippingCalculator = new ShippingCalculator();
            Action act = () => shippingCalculator.CalculateShipping(orderPrice);
            act.Should().Throw<ArgumentException>().WithMessage("The order price cannot be equal to or less than zero");
        }
    }
}
