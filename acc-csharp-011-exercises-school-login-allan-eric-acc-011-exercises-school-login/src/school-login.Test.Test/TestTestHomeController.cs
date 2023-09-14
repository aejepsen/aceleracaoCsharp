using Microsoft.AspNetCore.Mvc.Testing;

namespace SchoolLogin.Test.Test;

public class TestTestHomeController
{   
    WebApplicationFactory<Program> _factory = new WebApplicationFactory<Program>();

    [Trait("Category", "3 - Construa *endpoint* que necessita de autorização")]
    [Theory(DisplayName = "TestHomePrivateSuccess deve ser executado com sucesso")]
    [InlineData("tulio.olivieri@betrybe.com", "Tulio123")]
    [InlineData("marina.novais@betrybe.com", "Marina123")]
    [InlineData("jaqueline.milsted@betrybe.com", "Jack123")]
    [InlineData("arthur.procopio@betrybe.com", "Arthur123")]
    public async Task TestSuccessTestHomePrivateSuccess(string email, string password)
    {
        TestHomeController instance = new(_factory);
        Func<Task> act = async () => await instance.TestHomePrivateSuccess(email, password);
        await act.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
    }

    [Trait("Category", "3 - Construa *endpoint* que necessita de autorização")]
    [Theory(DisplayName = "TestHomePrivateSuccess deve falhar com input de falha")]
    [InlineData("tulio.olivieri@betrybe.com", "tulio123")]
    [InlineData("marina.novais@betrybe.co", "Marina123")]
    [InlineData("jaqueline.milsted@betrybe.com", "Jack12")]
    [InlineData("arthurprocopio@betrybe.com", "Arhur123")]
    public async Task TestFailTestHomePrivateSuccess(string email, string password)
    {
        TestHomeController instance = new(_factory);
        Func<Task> act = async () => await instance.TestHomePrivateSuccess(email, password);
        await act.Should().ThrowAsync<Xunit.Sdk.XunitException>();        
    }

    [Trait("Category", "3 - Construa *endpoint* que necessita de autorização")]
    [Theory(DisplayName = "TestHomePrivateUnauthorizedFail deve ser executado com sucesso")]
    [InlineData("tulio.olivieri@betrybe.com", "tulio123")]
    [InlineData("marina.novais@betrybe.co", "Marina123")]
    [InlineData("jaqueline.milsted@betrybe.com", "Jack12")]
    [InlineData("arthurprocopio@betrybe.com", "Arhur123")]
    [InlineData("", "tulio123")]
    [InlineData("marina.novais@betrybe.co", "")]
    [InlineData("", "")]
    public async Task TestSuccessTestHomePrivateUnauthorizedFail(string email, string password)
    {
        TestHomeController instance = new(_factory);
        Func<Task> act = async () => await instance.TestHomePrivateUnauthorizedFail(email, password);
        await act.Should().NotThrowAsync<Xunit.Sdk.XunitException>();                
    }

    [Trait("Category", "3 - Construa *endpoint* que necessita de autorização")]
    [Theory(DisplayName = "TestHomePrivateUnauthorizedFail deve falhar com input de falha")]
    [InlineData("tulio.olivieri@betrybe.com", "Tulio123")]
    [InlineData("marina.novais@betrybe.com", "Marina123")]
    [InlineData("jaqueline.milsted@betrybe.com", "Jack123")]
    [InlineData("arthur.procopio@betrybe.com", "Arthur123")]
    public async Task TestFailTestHomePrivateUnauthorizedFail(string email, string password)
    {
        TestHomeController instance = new(_factory);
        Func<Task> act = async () => await instance.TestHomePrivateUnauthorizedFail(email, password);
        await act.Should().ThrowAsync<Xunit.Sdk.XunitException>();           
    }
}
