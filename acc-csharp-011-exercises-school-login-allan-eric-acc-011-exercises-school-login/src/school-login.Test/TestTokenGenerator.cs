using SchoolLogin.Services;

namespace SchoolLogin.Test;

public class TestTokenGenerator
{
  /// <summary>
  /// Test function that validates if Token is being generated, if it is not returning null or empty
  /// </summary>
  [Fact]
  public void TestTokenGeneratorSuccess()
  {
    var token = new TokenGenerator().Generate();
    token.Should().NotBeNullOrEmpty();
  }

  /// <summary>
  /// Test function that validates if Token is being generated according to JWT methodology, having 3 keys.
  /// </summary>
  [Fact]
  public void TestTokenGeneratorKeysSuccess()
  {
    var token = new TokenGenerator().Generate();
    var tokenparts = token.Split(".");
    tokenparts.Length.Should().Be(3);
  }
}
