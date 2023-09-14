using FluentAssertions;
using Xunit;

namespace CharacterCounter.Test;

public class TestCharacterCounter
{    

        [Theory]
        [InlineData("x", 1)]
        [InlineData("xx", 2)]
        [InlineData("xxx", 3)]
        [InlineData("xxxx xxxx", 9)]

        public void TestCharacterCounterSuccess(string text, int resultExpected)
        {
            var characterCounter = new CharacterCounter();
            var stringLength = characterCounter.Action(text);
            stringLength.Should().Be(resultExpected);  
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TestCharacterCounterException(string text)
        {
            var characterCounter = new CharacterCounter();
            Action act = () => characterCounter.Action(text);
            act.Should().Throw<NullReferenceException>().WithMessage("Valor de texto inválido");
        }
}