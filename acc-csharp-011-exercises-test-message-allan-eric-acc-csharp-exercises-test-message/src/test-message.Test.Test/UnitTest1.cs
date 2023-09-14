using Xunit;
using FluentAssertions;
using System;

namespace test_message.Test.Test;

[Collection("Sequential")]
public class UnitTest1
{
    [Trait("Category", "1 - Criar o teste do PrintMsg")]
    [Theory(DisplayName = "TestPrintMsgSuccess deve ser executado com entradas corretas")]
    [InlineData("olá", "olá")]
    [InlineData("teste", "teste")]
    [InlineData("mensagem", "mensagem")]
    [InlineData("hello world", "hello world")]
    [InlineData("alguma coisa\n alguma coisa", "alguma coisa\n alguma coisa")]
    public void TestSuccessTestPrintMsgSuccess(string Entry, string Expected)
    {
        TestPrint instance = new();
        Action act = () => instance.TestPrintMsgSuccess(Entry, Expected);
        act.Should().NotThrow<Xunit.Sdk.XunitException>();
        act.Should().NotThrow<NotImplementedException>();
    }

    [Trait("Category", "1 - Criar o teste do PrintMsg")]
    [Theory(DisplayName = "TestPrintMsgSuccess deve falhar com entradas erradas")]
    [InlineData("ola", "olá")]
    [InlineData("teste1", "teste")]
    [InlineData("mensagem2", "mensagem")]
    [InlineData("hello world3", "hello world")]
    [InlineData("alguma coisa4\n alguma coisa", "alguma coisa\n alguma coisa")]
    public void TestFailTestOlaMundo(string Entry, string Expected)
    {
        TestPrint instance = new();
        Action act = () => instance.TestPrintMsgSuccess(Entry, Expected);
        act.Should().Throw<Xunit.Sdk.XunitException>();
        act.Should().NotThrow<NotImplementedException>();
    }
}
