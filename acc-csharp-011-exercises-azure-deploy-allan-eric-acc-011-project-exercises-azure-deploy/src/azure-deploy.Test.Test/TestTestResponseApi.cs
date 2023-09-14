using System.Net;
using FluentAssertions;

namespace AzureDeploy.Test.Test;

public class TestTestResponseApi
{   
    [Trait("Category", "3 - Adicione o Link da Aplicação no Projeto")]
    [Fact(DisplayName = "A requisição deve retornar Status Code 200")]
    public void TestSuccessTestStatusCodeApi()
    {
        var http = new HttpClient();
        var url = Helper.GetURLFromFile();        
        var response = http.GetAsync($"{url}/Deploy");     
        response.Result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Trait("Category", "3 - Adicione o Link da Aplicação no Projeto")]
    [Fact(DisplayName = "A requisição deve retornar valor do tipo string")]
    async public Task TestSuccessTestResponseApi()
    {
        const string resultExpected = "Estou realizando o deploy da minha API utilizando Azure";
        var http = new HttpClient();
        var url = Helper.GetURLFromFile();        
        var response = await http.GetAsync($"{url}/Deploy");     
        var content = response.Content.ReadAsStringAsync();
        content.Result.Should().Be(resultExpected);
    }
}