using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolLogin.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
  /// <summary>
  /// This function is to informate the current year
  /// </summary>
  /// <returns>The current year</returns>
  /// <response code="200">If the user have authorization will return the text </response>   
  /// <response code="401">If the user does not have authorization, an error will be returned.</response> 
  [HttpGet]
  [Authorize]
  public ActionResult<string> Private()
  {
    return Ok("Parabéns, você realizou a autenticação com sucesso!");
  }
}