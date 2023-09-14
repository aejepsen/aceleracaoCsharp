using Microsoft.AspNetCore.Mvc.Testing;

namespace MyWine.Test.Test;

public class TestTestAuthorizeMessageController
{   
    WebApplicationFactory<Program> _factory = new WebApplicationFactory<Program>();

    [Trait("Category", "1 - Criar Endpoint Anônimo")]
    [Theory(DisplayName = "TestMessageForCustomOfferSuccess deve ser executado com sucesso")]
    [InlineData("Bahia", "Lover")]
    [InlineData("Bahia", "Specialist")]
    [InlineData("Ceará", "Lover")]
    [InlineData("Ceará", "Specialist")]
    [InlineData("Minas Gerais", "Lover")]
    [InlineData("Minas Gerais", "Specialist")]
    [InlineData("Roraima", "Lover")]
    [InlineData("Roraima", "Specialist")]
    public async Task TestSuccessTestMessageForCustomOfferSuccess(string state, string type)
    {
        TestAuthorizeMessageController instance = new(_factory);
        Func<Task> act = async () => await instance.TestMessageForCustomOfferSuccess(state, type);
        await act.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
        await act.Should().NotThrowAsync<NotImplementedException>();
    }

    [Trait("Category", "1 - Criar Endpoint Anônimo")]
    [Theory(DisplayName = "TestMessageForCustomOfferSuccess deve falhar com input de falha")]
    [InlineData("São Paulo", "Lover")]
    [InlineData("Rio de Janeiro", "Specialist")]
    [InlineData("Acre", "Specialist")]
    [InlineData("Ceará", "Basic")]
    [InlineData("Minas Gerais", "Basic")]
    [InlineData("Roraima", "Basic")]
    public async Task TestFailTestMessageForCustomOfferSuccess(string state, string type)
    {
        TestAuthorizeMessageController instance = new(_factory);
        Func<Task> act = async () => await instance.TestMessageForCustomOfferSuccess(state, type);
        await act.Should().ThrowAsync<Xunit.Sdk.XunitException>();
        await act.Should().NotThrowAsync<NotImplementedException>();
    }
}
public class TestTestAuthorizeMessageController2
{
    WebApplicationFactory<Program> _factory = new WebApplicationFactory<Program>();

    [Trait("Category", "2 - Criar Endpoint com Autorização")]
    [Theory(DisplayName = "TestMessageForCustomOfferFail deve ser executado com sucesso")]
    [InlineData("São Paulo", "Lover")]
    [InlineData("Rio de Janeiro", "Specialist")]
    [InlineData("Acre", "Specialist")]
    [InlineData("Ceará", "Basic")]
    [InlineData("Minas Gerais", "Basic")]
    [InlineData("Roraima", "Basic")]
    public async Task TestSuccessTestMessageForCustomOfferFail(string state, string type)
    {
        TestAuthorizeMessageController instance = new(_factory);
        Func<Task> act = async () => await instance.TestMessageForCustomOfferFail(state, type);
        await act.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
        await act.Should().NotThrowAsync<NotImplementedException>();
    }

    [Trait("Category", "2 - Criar Endpoint com Autorização")]
    [Theory(DisplayName = "TestMessageForCustomOfferFail deve falhar com input de falha")]
    [InlineData("Bahia", "Lover")]
    [InlineData("Bahia", "Specialist")]
    [InlineData("Ceará", "Lover")]
    [InlineData("Ceará", "Specialist")]
    [InlineData("Minas Gerais", "Lover")]
    [InlineData("Minas Gerais", "Specialist")]
    [InlineData("Roraima", "Lover")]
    [InlineData("Roraima", "Specialist")]
    public async Task TestFailTestMessageForCustomOfferFail(string state, string type)
    {
        TestAuthorizeMessageController instance = new(_factory);
        Func<Task> act = async () => await instance.TestMessageForCustomOfferFail(state, type);
        await act.Should().ThrowAsync<Xunit.Sdk.XunitException>();
        await act.Should().NotThrowAsync<NotImplementedException>();
    }
}
public class TestTestAuthorizeMessageController3
{
    WebApplicationFactory<Program> _factory = new WebApplicationFactory<Program>();

    [Trait("Category", "3 - Criar Endpoint com Autorização baseada em `Claims`")]
    [Theory(DisplayName = "TestMessageForCustomersSuccess deve ser executado com sucesso")]
    [InlineData("Bahia", "Lover")]
    [InlineData("Bahia", "Specialist")]
    [InlineData("Ceará", "Lover")]
    [InlineData("Ceará", "Specialist")]
    [InlineData("Minas Gerais", "Lover")]
    [InlineData("Minas Gerais", "Specialist")]
    [InlineData("Roraima", "Lover")]
    [InlineData("Roraima", "Specialist")]
    [InlineData("São Paulo", "Lover")]
    [InlineData("Rio de Janeiro", "Specialist")]
    [InlineData("Acre", "Specialist")]
    [InlineData("Ceará", "Basic")]
    [InlineData("Minas Gerais", "Basic")]
    [InlineData("Roraima", "Basic")]
    public async Task TestSuccessTestMessageForCustomersSuccess(string state, string type)
    {
        TestAuthorizeMessageController instance = new(_factory);
        Func<Task> act = async () => await instance.TestMessageForCustomersSuccess(state, type);
        await act.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
        await act.Should().NotThrowAsync<NotImplementedException>();
    }

    [Trait("Category", "3 - Criar Endpoint com Autorização baseada em `Claims`")]
    [Theory(DisplayName = "TestMessageForCustomersFail deve ser executado com sucesso")]
    [InlineData("TOKENINVALIDO")]
    [InlineData("TRYBE")]
    [InlineData("123456789")]
    public async Task TestSuccessTestMessageForCustomersFail(string token)
    {
        TestAuthorizeMessageController instance = new(_factory);
        Func<Task> act = async () => await instance.TestMessageForCustomersFail(token);
        await act.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
        await act.Should().NotThrowAsync<NotImplementedException>();
    }

    [Trait("Category", "3 - Criar Endpoint com Autorização baseada em `Claims`")]
    [Fact(DisplayName = "TestMessageForEveryoneSuccess deve ser executado com sucesso")]
    public async Task TestSuccessTestMessageForEveryoneSuccess()
    {
        TestAuthorizeMessageController instance = new(_factory);
        Func<Task> act = async () => await instance.TestMessageForEveryoneSuccess();
        await act.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
        await act.Should().NotThrowAsync<NotImplementedException>();
    }
}
