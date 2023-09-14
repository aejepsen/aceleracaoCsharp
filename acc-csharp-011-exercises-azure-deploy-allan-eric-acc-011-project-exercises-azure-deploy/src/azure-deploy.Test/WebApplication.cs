using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace AzureDeploy.Test;

public class WebApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        return base.CreateHost(builder);
    }

     public async Task<HttpResponseMessage> ApiGetRequest(string route)
    {
        var client = CreateClient();
        return await client.GetAsync(route);
    }
}