using Microsoft.AspNetCore.Mvc;
using SchoolLogin.Models;
using SchoolLogin.Repositories;
using SchoolLogin.Services;

namespace SchoolLogin.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
  public StudentRepository Repository { get; set; }
  public LoginController(StudentRepository repository)
  {
    Repository = repository;
  }
  /// <summary>
  /// This function is to Login Student
  /// </summary>
  /// <returns>The token JWT</returns>
  /// <response code="200">If the student is found and the token generation goes well</response>   
  /// <response code="400">If an exception occurs</response>  
  /// <response code="404">If a student is not found</response>  
  [HttpPost]
  public ActionResult<string> Login([FromBody] Student student)
  {
    try
    {
      var isStudentExists = StudentRepository.StudentExists(student);
      if (!isStudentExists) return NotFound();
      var token = new TokenGenerator().Generate();
      return Ok(token);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}