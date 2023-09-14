using ola_mundo;
using System.IO;
using Xunit;
using System;

namespace ola_mundo.Test;

public class OlaMundoTest
{
    [Theory(DisplayName = "Deve exibir Olá, Mundo!")]
    [InlineData("Olá, Mundo!")]
    public void TestOlaMundo(string Expected)
    {
        Assert.Equal(HelloWorld.Greet(), Expected);
        Assert.NotEqual(HelloWorld.Greet(), "Hello World!");
    }
}
