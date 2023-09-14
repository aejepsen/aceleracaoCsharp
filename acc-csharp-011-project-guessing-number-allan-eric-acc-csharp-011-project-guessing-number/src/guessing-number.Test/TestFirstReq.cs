using Xunit;
using System.IO;
using System;
using guessing_number;
using FluentAssertions;

namespace guessing_number.Test;

[Collection("Sequential")]
public class TestFirstReq
{
    [Theory(DisplayName = "Deve exibir mensagem inicial!")]
    [InlineData("---Bem-vindo ao Guessing Game--- /n Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!")]
    public void TestGreet(string expected)
    {
        //Arrange
        var game = new GuessNumber();

        //Act
        var result = game.Greet();

        //Assert
        result.Should().Be(expected);
    }

    [Theory(DisplayName = "Deve receber a entrada do usuário e converter para int")]
    [InlineData("10", 10)]
    [InlineData("20", 20)]
    [InlineData("30", 30)]
    [InlineData("-99", -99)]
    [InlineData("-45", -45)]
    [InlineData("0", 0)]
    public void TestReceiveUserInputAndConvert(string entry, int expected)
    {
        //Arrange
        var game = new GuessNumber();

        //Act
        var result = game.ChooseNumber(entry);
        var resultInt = result.Split(" ")[2];

        //Assert
        resultInt.Should().Be(expected.ToString());
        // result.Should().Be(expected.ToString());
    }

    [Theory(DisplayName = "Deve retornar mensagem de erro quando entrada não for inteiro.")]
    [InlineData("1sony0")]
    [InlineData("")]
    [InlineData("teste")]
    [InlineData("alala")]
    [InlineData("trybe")]
    public void TestReceiveUserInputAndVerifyType(string entry)
    {
        //Arrange
        var game = new GuessNumber();

        //Act
        var result = game.ChooseNumber(entry);

        //Assert
        result.Should().Be("Entrada inválida! Não é um número.");
    }

    [Theory(DisplayName = "Deve receber a entrada do usuário e garantir que está entre -100 e 100!")]
    [InlineData("1000")]
    [InlineData("-1000")]
    [InlineData("-101")]
    [InlineData("101")]
    [InlineData("9999")]
    public void TestReceiveUserInputAndVerifyRange(string entry)
    {
                //Arrange
        var game = new GuessNumber();

        //Act
        var result = game.ChooseNumber(entry);

        //Assert

        result.Should().Be("Entrada inválida! Valor não está no range.");

    }
}
