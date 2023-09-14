using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;

namespace election_day.Test;

public class TestThirdReq
{
    [Theory(DisplayName = "Deve computar multiplos votos")]
    [InlineData(new int[]{1,1,1,2,2,3,0,0,0,0,0,0,0}, 3, 2, 1, 7)]
    public void TestMultipleVotes(
        int[] votes,
        int expectedReceivedOption1,
        int expectedReceivedOption2,
        int expectedReceivedOption3,
        int expectedOptionNull)
    {
        // Arrange
        var ballotBox = new BallotBox();
        ballotBox.Start();
        // Act
        ballotBox.MultipleVotes(votes);
        // Assert
        ballotBox.VotesOption1.Should().Be(expectedReceivedOption1);
        ballotBox.VotesOption2.Should().Be(expectedReceivedOption2);
        ballotBox.VotesOption3.Should().Be(expectedReceivedOption3);
        ballotBox.VotesNull.Should().Be(expectedOptionNull);
    }
}
