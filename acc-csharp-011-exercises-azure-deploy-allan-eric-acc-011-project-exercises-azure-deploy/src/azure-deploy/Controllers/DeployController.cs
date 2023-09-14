using Microsoft.AspNetCore.Mvc;

namespace AzureDeploy.Controllers;

[ApiController]
[Route("[controller]")]
public class DeployController : ControllerBase
{
    /// <summary>
    /// This function is to create a unique controller 
    /// </summary>
    /// <returns>The a phrase </returns>
    [HttpGet]
    public string Get()
    {
        return "Estou realizando o deploy da minha API utilizando Azure";
    }
}
