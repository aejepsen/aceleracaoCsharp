using Xunit;
using System;
using FluentAssertions;
using election_day.Test;

namespace election_day.Test.Test;

public class TestTestThirdReq
{
    [Trait("Category", "3 - Implemente a função MultipleVotes() para a urna e seus testes.")]
    [Theory(DisplayName = "TestMultipleVotes deve ser executado com sucesso com entradas corretas.")]
    [InlineData(new int[]{1,1,1,2,2,3,0,0,0,0,0,0,0}, 3, 2, 1, 7)]
    public void TestSucessTestMultipleVotes(
        int[] votes,
        int expectedReceivedOption1,
        int expectedReceivedOption2,
        int expectedReceivedOption3,
        int expectedOptionNull)
    {
        TestThirdReq instance = new();
        Action act = () => instance.TestMultipleVotes(votes, expectedReceivedOption1, expectedReceivedOption2, expectedReceivedOption3, expectedOptionNull);
        act.Should().NotThrow<Xunit.Sdk.XunitException>();
        act.Should().NotThrow<NotImplementedException>();
    }

    [Trait("Category", "3 - Implemente a função MultipleVotes() para a urna e seus testes.")]
    [Theory(DisplayName = "TestMultipleVotes deve falhar com entradas incorretas.")]
    [InlineData(new int[]{1,1,1,2,2,3,0,0,0,0,0,0,0}, 4, 2, 1, 7)]
    [InlineData(new int[]{1,1,1,2,2,3,0,0,0,0,0,0,0}, 3, 3, 1, 7)]
    [InlineData(new int[]{1,1,1,2,2,3,0,0,0,0,0,0,0}, 4, 2, 3, 7)]
    [InlineData(new int[]{1,1,1,2,2,3,0,0,0,0,0,0,0}, 4, 2, 1, 4)]
    public void TestFailTestMultipleVotes(
        int[] votes,
        int expectedReceivedOption1,
        int expectedReceivedOption2,
        int expectedReceivedOption3,
        int expectedOptionNull)
    {
        TestThirdReq instance = new();
        Action act = () => instance.TestMultipleVotes(votes, expectedReceivedOption1, expectedReceivedOption2, expectedReceivedOption3, expectedOptionNull);
        act.Should().Throw<Xunit.Sdk.XunitException>();
        act.Should().NotThrow<NotImplementedException>();
    }

}
