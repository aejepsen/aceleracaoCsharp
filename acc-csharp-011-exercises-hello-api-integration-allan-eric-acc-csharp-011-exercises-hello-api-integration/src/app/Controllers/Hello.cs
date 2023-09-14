using Microsoft.AspNetCore.Mvc;
// ok
namespace app.Controllers;

[ApiController]
public class HelloController : ControllerBase
{

    private readonly ILogger<HelloController> _logger;

    public HelloController(ILogger<HelloController> logger)
    {
        _logger = logger;
    }

    [Route("[controller]")]
    [HttpGet]    
    public string Get()
    {
        return "hello, use /{language} to get a hello in your language!";
    }

    [Route("[controller]/{language}")]
    [HttpGet]
    public string Get(string language)
    {
        return language switch
        {
            "br" => "[br] : Olá",
            "en" => "[en] : Hello",
            "es" => "[es] : Hola",
            "de" => "[de] : Hallo",
            _ => "Não conheço essa!",
        };
    }
}
