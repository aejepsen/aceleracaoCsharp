using Xunit;
using FluentAssertions;
using System.IO;
using CommissionCalculation;
using System.Threading;
using System.Globalization;

namespace CommissionCalculation.Test;

public class CommissionCalculatorTest
{
    [Theory(DisplayName = "Deve calcular corretamente o salário, armazenar e retornar o resultado no atributo FinalSalary.")]
    [InlineData(1200, 2, 60000, 3500)]
    public void TestCalculateFinalSalary(decimal fixedSalary, int amountCarsSold, decimal totalSalesValue, decimal expectedFinalSalary)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);

        var calculator = new CommissionCalculator();

        calculator.CalculateFinalSalary(fixedSalary, amountCarsSold, totalSalesValue);

        calculator.FixedSalary.Should().Be(fixedSalary);
        calculator.AmountCarsSold.Should().Be(amountCarsSold);
        calculator.TotalSalesValue.Should().Be(totalSalesValue);
        calculator.FinalSalary.Should().Be(expectedFinalSalary);

    }

    [Theory(DisplayName = "Deve retornar corretamente a mensagem de salário final.")]
    [InlineData("Nome Contribuidor", "janeiro",
        "O colaborador Nome Contribuidor neste mês de janeiro obteve o salário final de R$0.00 referente à: SALARIO FIXO: R$0.00 TOTAL DE CARROS VENDIDOS: 0 VALOR TOTAL DE VENDAS NO MES: R$0.00 COMISSÃO POR CARROS VENDIDOS: R$250.00 COMISSÃO DE 3% DO TOTAL DE VENDAS: R$0.00"
    )]
    public void TestShowFinalSalary(string contributorName, string month, string expectedMessage)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);

        var calculator = new CommissionCalculator();

        string result = calculator.GetFinalSalary(contributorName, month);

        result.Should().Be(expectedMessage);

    }
}