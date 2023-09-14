using Microsoft.AspNetCore.Mvc.Testing;

namespace SchoolLogin.Test.Test;

public class TestTestLoginController
{
    WebApplicationFactory<Program> _factory = new WebApplicationFactory<Program>();

    [Trait("Category", "2 - Construa o *endpoint* com ação de Login na `API`")]
    [Theory(DisplayName = "TestLoginSuccess deve ser executado com sucesso")]
    [InlineData("tulio.olivieri@betrybe.com", "Tulio123")]
    [InlineData("marina.novais@betrybe.com", "Marina123")]
    [InlineData("jaqueline.milsted@betrybe.com", "Jack123")]
    [InlineData("arthur.procopio@betrybe.com", "Arthur123")]
    public async Task TestSuccessTestLoginSuccess(string email, string password)
    {
        TestLoginController instance = new(_factory);
        Func<Task> act = async () => await instance.TestLoginSuccess(email, password);
        await act.Should().NotThrowAsync<Xunit.Sdk.XunitException>();             
    }

    [Trait("Category", "2 - Construa o *endpoint* com ação de Login na `API`")]
    [Theory(DisplayName = "TestLoginSuccess deve falhar com input de falha")]
    [InlineData("tulio.olivieri@betrybe.com", "tulio123")]
    [InlineData("marina.novais@betrybe.co", "Marina123")]
    [InlineData("jaqueline.milsted@betrybe.com", "Jack12")]
    [InlineData("arthurprocopio@betrybe.com", "Arhur123")]
    public async Task TestFailTestLoginSuccess(string email, string password)
    {
        TestLoginController instance = new(_factory);
        Func<Task> act = async () => await instance.TestLoginSuccess(email, password);
        await act.Should().ThrowAsync<Xunit.Sdk.XunitException>();     
    }

    [Trait("Category", "2 - Construa o *endpoint* com ação de Login na `API`")]
    [Theory(DisplayName = "TestLoginNotFoundFail deve ser executado com sucesso")]
    [InlineData("tulio.olivieri@betrybe.com", "tulio123")]
    [InlineData("marina.novais@betrybe.co", "Marina123")]
    [InlineData("jaqueline.milsted@betrybe.com", "Jack12")]
    [InlineData("arthurprocopio@betrybe.com", "Arhur123")]
    public async Task TestSuccessTestLoginNotFoundFail(string email, string password)
    {
        TestLoginController instance = new(_factory);
        Func<Task> act = async () => await instance.TestLoginNotFoundFail(email, password);
        await act.Should().NotThrowAsync<Xunit.Sdk.XunitException>();  
    }

    [Trait("Category", "2 - Construa o *endpoint* com ação de Login na `API`")]
    [Theory(DisplayName = "TestLoginNotFoundFail deve falhar com input de falha")]
    [InlineData("tulio.olivieri@betrybe.com", "Tulio123")]
    [InlineData("marina.novais@betrybe.com", "Marina123")]
    [InlineData("jaqueline.milsted@betrybe.com", "Jack123")]
    [InlineData("arthur.procopio@betrybe.com", "Arthur123")]
    public async Task TestFailTestLoginNotFoundFail(string email, string password)
    {
        TestLoginController instance = new(_factory);
        Func<Task> act = async () => await instance.TestLoginNotFoundFail(email, password);
        await act.Should().ThrowAsync<Xunit.Sdk.XunitException>();          
    }

    [Trait("Category", "2 - Construa o *endpoint* com ação de Login na `API`")]
    [Theory(DisplayName = "TestLoginBadRequestFail deve ser executado com sucesso")]
    [InlineData("", "tulio123")]
    [InlineData("marina.novais@betrybe.co", "")]
    [InlineData("", "")]
    public async Task TestSuccessTestLoginBadRequestFail(string email, string password)
    {
        TestLoginController instance = new(_factory);
        Func<Task> act = async () => await instance.TestLoginBadRequestFail(email, password);
        await act.Should().NotThrowAsync<Xunit.Sdk.XunitException>();   
    }

    [Trait("Category", "2 - Construa o *endpoint* com ação de Login na `API`")]
    [Theory(DisplayName = "TestLoginBadRequestFail deve falhar com input de falha")]
    [InlineData("tulio.olivieri@betrybe.com", "Tulio123")]
    [InlineData("marina.novais@betrybe.com", "Marina123")]
    [InlineData("jaqueline.milsted@betrybe.com", "Jack123")]
    [InlineData("arthur.procopio@betrybe.com", "Arthur123")]
    public async Task TestFailTestLoginBadRequestFail(string email, string password)
    {
        TestLoginController instance = new(_factory);
        Func<Task> act = async () => await instance.TestLoginBadRequestFail(email, password);
        await act.Should().ThrowAsync<Xunit.Sdk.XunitException>();          
    }
}
