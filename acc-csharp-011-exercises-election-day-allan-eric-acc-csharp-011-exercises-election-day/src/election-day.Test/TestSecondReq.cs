using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;

namespace election_day.Test;

[Collection("Sequential")]
public class TestSecondReq
{
    [Theory(DisplayName = "Deve computar um único voto.")]
    [InlineData(2)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(0)]
    public void TestUniqueVote(int vote)
    {
        // Arrange
        var ballotBox = new BallotBox();
        ballotBox.Start();
        var expected = 1;
        // Act
        ballotBox.UniqueVote(vote);
        // Assert
        switch (vote)
        {
            case 1:
                ballotBox.VotesOption1.Should().Be(expected);
                break;
            case 2:
                ballotBox.VotesOption2.Should().Be(expected);
                break;
            case 3:
                ballotBox.VotesOption3.Should().Be(expected);
                break;
            case 0:
                ballotBox.VotesNull.Should().Be(expected);
                break;
            default:
                break;
        }
    }
}
