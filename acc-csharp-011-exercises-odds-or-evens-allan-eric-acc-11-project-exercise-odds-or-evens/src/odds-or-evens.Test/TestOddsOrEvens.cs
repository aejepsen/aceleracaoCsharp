using FluentAssertions;
using Xunit;

namespace OddsOrEvens.Test;

public class TestOddsOrEvens
{
    [Theory(DisplayName = "Teste de sucesso para verificar se a soma entre dois números é par ou ímpar")]
    [InlineData(2, 7, "Ímpar")]
    [InlineData(2, 2, "Par")]
    [InlineData(2, 7, "Ímpar")]
    [InlineData(1, 1, "Par")]


    public void TestOddsOrEvensSuccess(int numberOne, int numberTwo, string resultExpected)
    {
        var oddsOrEvens = new OddsOrEvens();
        var result = oddsOrEvens.SumNumbers(numberOne, numberTwo);
        var resultValue = oddsOrEvens.VerifyOddsOrEvens(result);
        resultValue.Should().Be(resultExpected);
    }

    [Theory(DisplayName = "Teste de exceção para verificar se a soma entre dois números é par ou ímpar")]
    [InlineData(10, 11)]
    [InlineData(-10,3)]
    public void TestOddsOrEvensException(int numberOne, int numberTwo)
    {
        var oddsOrEvens = new OddsOrEvens();
        Assert.Throws<ArgumentOutOfRangeException>(() => oddsOrEvens.SumNumbers(numberOne, numberTwo));
    }
}
