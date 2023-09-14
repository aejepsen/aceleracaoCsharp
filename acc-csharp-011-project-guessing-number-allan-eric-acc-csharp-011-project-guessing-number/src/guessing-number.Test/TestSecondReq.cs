using Xunit;
using System.IO;
using System;
using Moq;
using guessing_number;
using FluentAssertions;

namespace guessing_number.Test;

[Collection("Sequential")]
public class TestSecondReq
{
    [Theory(DisplayName = "Deve escolher randomicamente um número entre -100 e 100!")]
    [InlineData(-100, 100)]
    public void TestRandomlyChooseANumber(int MinimumRange, int MaximumRange)
    {
        var IRandomMock = new Mock<IRandomGenerator>();
        var guessInstance = new GuessNumber(IRandomMock.Object);
        guessInstance.randomValue.Should().Be(0);
        var message = guessInstance.RandomNumber();
        message.Should().Be("A máquina escolheu um número de -100 à 100! ");
        guessInstance.randomValue.Should().BeInRange(MinimumRange, MaximumRange);

    }
// teste do teste não passou test fail.
    [Theory(DisplayName = "Deve comparar a entrada do usuário em um caso MENOR")]
    [InlineData(50, 30)]
    [InlineData(50, 10)]
    [InlineData(50, -100)]
    [InlineData(50, 49)]
    [InlineData(50, 0)]
    public void TestProgramComparisonValuesLess(int mockValue, int entry)
    {
// O teste deve criar uma instancia de GuessingGame O teste deve verificar se inicialmente o valor da variável userValue é 0 O teste deve verificar se inicialmente o valor da variável randomValue é 0 O teste deve chamar a mockar a função RandomNumber() com  Moq.Mock<IRandomGenerator> O teste deve verificar se a função retorna a string correta para um resultado menor em TestProgramComparisonValuesLess() O teste deve verificar se a função retorna a string correta para um resultado maior em TestProgramComparisonValuesBigger() O teste deve verificar se a função retorna a string correta para um resultado igual em TestProgramComparisonValuesEqual()

        var IRandomMock = new Mock<IRandomGenerator>();
        IRandomMock.Setup(randomGen => randomGen.GetInt(It.IsAny<int>(), It.IsAny<int>())).Returns(mockValue);

        GuessNumber guessNumber = new(IRandomMock.Object);
        guessNumber.userValue.Should().Be(0);
        guessNumber.randomValue.Should().Be(0);

        guessNumber.RandomNumber();

        guessNumber.userValue = entry;
        var playCheck = guessNumber.AnalyzePlay();
        playCheck.Should().Be("Tente um número MAIOR");

              
    }

    [Theory(DisplayName = "Deve comparar a entrada do usuário em um caso MAIOR")]
    [InlineData(50, 60)]
    [InlineData(50, 90)]
    [InlineData(50, 100)]
    [InlineData(50, 51)]
    [InlineData(50, 77)]
    public void TestProgramComparisonValuesBigger(int mockValue, int entry)
    {

        var IRandomMock = new Mock<IRandomGenerator>();
        IRandomMock.Setup(randomGen => randomGen.GetInt(It.IsAny<int>(), It.IsAny<int>())).Returns(mockValue);

        GuessNumber guessNumber = new(IRandomMock.Object);
        guessNumber.userValue.Should().Be(0);
        guessNumber.randomValue.Should().Be(0);

        guessNumber.RandomNumber();

        guessNumber.userValue = entry;
        var playCheck = guessNumber.AnalyzePlay();
        playCheck.Should().Be("Tente um número MENOR");
    }

    [Theory(DisplayName = "Deve comparar a entrada do usuário em um caso IGUAL")]
    [InlineData(50, 50)]
    [InlineData(100, 100)]
    [InlineData(-99, -99)]
    [InlineData(0, 0)]
    [InlineData(77, 77)]
    public void TestProgramComparisonValuesEqual(int mockValue, int entry)
    {
        var IRandomMock = new Mock<IRandomGenerator>();
        IRandomMock.Setup(randomGen => randomGen.GetInt(It.IsAny<int>(), It.IsAny<int>())).Returns(mockValue);

        GuessNumber guessNumber = new(IRandomMock.Object);
        guessNumber.userValue.Should().Be(0);
        guessNumber.randomValue.Should().Be(0);

        guessNumber.RandomNumber();

        guessNumber.userValue = entry;
        var playCheck = guessNumber.AnalyzePlay();
        playCheck.Should().Be("ACERTOU!");                
    }
}

// recebi ajuda dos colegas de turma para entender como mocar a geração de números aleatorios. Thiago Zardo, João V Dias e Júnior(Carlos Alberto Souza Lima Júnior)
