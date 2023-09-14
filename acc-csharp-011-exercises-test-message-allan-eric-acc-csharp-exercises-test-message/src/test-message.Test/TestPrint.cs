using Xunit;
using FluentAssertions;
using System.IO;
using System;

namespace test_message.Test;

public class TestPrint
{
    [Theory]
    [InlineData("olá", "olá")]
    [InlineData("teste", "teste")]
    [InlineData("mensagem", "mensagem")]
    [InlineData("hello world", "hello world")]
    [InlineData("alguma coisa\n alguma coisa", "alguma coisa\n alguma coisa")]
    public void TestPrintMsgSuccess(string Send, string Expected)
    {
        var result = Message.PrintMsg(Send);
        result.Should().Be(Expected);
        // throw new NotImplementedException();
    }
}
