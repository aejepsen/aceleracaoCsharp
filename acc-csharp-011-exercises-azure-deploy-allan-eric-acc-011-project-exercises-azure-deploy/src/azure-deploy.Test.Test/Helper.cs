using System.Reflection;

namespace AzureDeploy.Test.Test;

public static class Helper
{
    public static string GetURLFromFile() 
    {
        return File.ReadAllText("../../../../azure-deploy.Test/azure_url.txt");
    }
}
