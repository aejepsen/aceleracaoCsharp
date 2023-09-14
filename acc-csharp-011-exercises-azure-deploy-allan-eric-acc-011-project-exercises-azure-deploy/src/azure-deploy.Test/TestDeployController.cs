using System.Net;
using FluentAssertions;

namespace AzureDeploy.Test;

public class TestDeployController
{
  /// <summary>
  /// This function is to test the api controller requests
  /// </summary>
  [Fact]
  public void TestGetStatusCodeSuccess()
  {
    var res = new WebApplication().ApiGetRequest("/Deploy");
    res.Result.StatusCode.Should().Be(HttpStatusCode.OK);
    var resString = res.Result.Content.ReadAsStringAsync();
    resString.Result.Should().Be("Estou realizando o deploy da minha API utilizando Azure");
  }
}