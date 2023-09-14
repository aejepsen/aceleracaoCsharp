using Xunit;
using System;
using FluentAssertions;
using election_day.Test;

namespace election_day.Test.Test;

public class TestTestFirstReq
{
    [Trait("Category", "1 - Implemente a função de Start() para a urna e seus testes")]
    [Fact(DisplayName = "TestStart deve ser executado com sucesso.")]
    public void TestSucessTestStart()
    {
        TestFirstReq instance = new();
        Action act = () => instance.TestStart();
        act.Should().NotThrow<Xunit.Sdk.XunitException>();
        act.Should().NotThrow<NotImplementedException>();
    }
}
