using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;

namespace election_day.Test;

public class TestFirstReq
{
    [Fact(DisplayName = "Deve iniciar os votos como 0")]
    public void TestStart()
    {
        // Arrange
        var ballotBox = new BallotBox();
        // Act
        ballotBox.Start();
        // Assert
        ballotBox.VotesOption1.Should().Be(0);
        ballotBox.VotesOption2.Should().Be(0);
        ballotBox.VotesOption3.Should().Be(0);
        ballotBox.VotesNull.Should().Be(0);
    }
}
