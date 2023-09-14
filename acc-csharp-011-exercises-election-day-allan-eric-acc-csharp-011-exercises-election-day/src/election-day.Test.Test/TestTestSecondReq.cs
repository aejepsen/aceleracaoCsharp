using Xunit;
using System;
using FluentAssertions;
using election_day.Test;

namespace election_day.Test.Test;

public class TestTestSecondReq
{
    [Trait("Category", "2 - Implemente a função UniqueVote() para a urna e seus testes.")]
    [Theory(DisplayName = "TestUniqueVote deve ser executado com sucesso.")]
    [InlineData(2)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(0)]
    public void TestSucessTestUniqueVote(int vote)
    {
        TestSecondReq instance = new();
        Action act = () => instance.TestUniqueVote(vote);
        act.Should().NotThrow<Xunit.Sdk.XunitException>();
        act.Should().NotThrow<NotImplementedException>();
    }
}
