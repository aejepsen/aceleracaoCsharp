using FluentAssertions;
using LoggingIn.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Sdk;

namespace LoggingIn.Test.Test;

public class AnimalControllerTestTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly AnimalControllerTest _instance;
    private readonly Mock<ILogger<AnimalController>> _loggerMock;

    public AnimalControllerTestTest(WebApplicationFactory<Program> factory)
    {
        _instance = new AnimalControllerTest(factory);
        _loggerMock = _instance._loggerMock;
    }

    [Trait("Category", "1 - Crie logs para o método `GetAll()`")]    
    [Fact(DisplayName = "1 - Crie logs para o método `GetAll()`")]
    public async Task GetAllSuccessTest()
    {
        Func<Task> act = () => _instance.GetAllSuccessTest();

        await act.Should().NotThrowAsync<NotImplementedException>();
        await act.Should().NotThrowAsync<XunitException>();

        var invocations = _loggerMock.Invocations.ToList();

        _loggerMock.Invocations.Should().HaveCount(2);

        foreach (var invocation in invocations)
        {
            invocation.Arguments.Should().HaveCount(5);
            invocations[0].Arguments[0].Should().Be(LogLevel.Information);
            invocations[0].Arguments[2].ToString().Should().Be("GetAll executed with 3 animals");
        }
    }
}
public class AnimalControllerTestTest2 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly AnimalControllerTest _instance;
    private readonly Mock<ILogger<AnimalController>> _loggerMock;

    public AnimalControllerTestTest2(WebApplicationFactory<Program> factory)
    {
        _instance = new AnimalControllerTest(factory);
        _loggerMock = _instance._loggerMock;
    }
    
    [Trait("Category", "2 - Crie logs para o método `GetById()`")]
    [Fact(DisplayName = "2 - Crie logs para o método `GetById()`")]
    public async Task GetByIdSuccessTest()
    {
        Func<Task> act = () => _instance.GetByIdSuccessTest();

        await act.Should().NotThrowAsync<NotImplementedException>();
        await act.Should().NotThrowAsync<XunitException>();

        var invocations = _loggerMock.Invocations.ToList();

        _loggerMock.Invocations.Should().HaveCount(2);

        foreach (var invocation in invocations)
        {
            invocation.Arguments.Should().HaveCount(5);
            invocations[0].Arguments[0].Should().Be(LogLevel.Information);
            invocations[0].Arguments[2].ToString().Should().Be("GetById executed with id 1");
        }
    }

    [Trait("Category", "2 - Crie logs para o método `GetById()`")]
    [Fact(DisplayName = "2 - Crie logs para o método `GetById()`")]
    public async Task GetByIdNotFoundTest()
    {
        Func<Task> act = () => _instance.GetByIdNotFoundTest();

        await act.Should().NotThrowAsync<NotImplementedException>();
        await act.Should().NotThrowAsync<XunitException>();

        var invocations = _loggerMock.Invocations.ToList();

        _loggerMock.Invocations.Should().HaveCount(2);

        foreach (var invocation in invocations)
        {
            invocation.Arguments.Should().HaveCount(5);
            invocations[0].Arguments[0].Should().Be(LogLevel.Warning);
            invocations[0].Arguments[2].ToString().Should().Be("GetById failed: the animal with id 1 was not found");
        }
    }

}
public class AnimalControllerTestTest3 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly AnimalControllerTest _instance;
    private readonly Mock<ILogger<AnimalController>> _loggerMock;

    public AnimalControllerTestTest3(WebApplicationFactory<Program> factory)
    {
        _instance = new AnimalControllerTest(factory);
        _loggerMock = _instance._loggerMock;
    }

    [Trait("Category", "3 - Crie logs para o método `Create()`")]
    [Fact(DisplayName = "3 - Crie logs para o método `Create()`")]
    public async Task CreateSuccessTest()
    {
        Func<Task> act = () => _instance.CreateSuccessTest();

        await act.Should().NotThrowAsync<NotImplementedException>();
        await act.Should().NotThrowAsync<XunitException>();

        var invocations = _loggerMock.Invocations.ToList();

        _loggerMock.Invocations.Should().HaveCount(2);

        foreach (var invocation in invocations)
        {
            invocation.Arguments.Should().HaveCount(5);
            invocations[0].Arguments[0].Should().Be(LogLevel.Information);
            invocations[0].Arguments[2].ToString().Should().Be("Create executed with id 1");
        }
    }

}
public class AnimalControllerTestTest4 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly AnimalControllerTest _instance;
    private readonly Mock<ILogger<AnimalController>> _loggerMock;

    public AnimalControllerTestTest4(WebApplicationFactory<Program> factory)
    {
        _instance = new AnimalControllerTest(factory);
        _loggerMock = _instance._loggerMock;
    }

    [Trait("Category", "4 - Crie logs para o método `Update()`")]
    [Fact(DisplayName = "4 - Crie logs para o método `Update()`")]
    public async Task UpdateSuccessTest()
    {
        Func<Task> act = () => _instance.UpdateSuccessTest();

        await act.Should().NotThrowAsync<NotImplementedException>();
        await act.Should().NotThrowAsync<XunitException>();

        var invocations = _loggerMock.Invocations.ToList();

        _loggerMock.Invocations.Should().HaveCount(2);

        foreach (var invocation in invocations)
        {
            invocation.Arguments.Should().HaveCount(5);
            invocations[0].Arguments[0].Should().Be(LogLevel.Information);
            invocations[0].Arguments[2].ToString().Should().Be("Update executed with id 1");
        }
    }

    [Trait("Category", "4 - Crie logs para o método `Update()`")]
    [Fact(DisplayName = "4 - Crie logs para o método `Update()`")]
    public async Task UpdateNotFoundTest()
    {
        Func<Task> act = () => _instance.UpdateNotFoundTest();

        await act.Should().NotThrowAsync<NotImplementedException>();
        await act.Should().NotThrowAsync<XunitException>();

        var invocations = _loggerMock.Invocations.ToList();

        _loggerMock.Invocations.Should().HaveCount(2);

        foreach (var invocation in invocations)
        {
            invocation.Arguments.Should().HaveCount(5);
            invocations[0].Arguments[0].Should().Be(LogLevel.Warning);
            invocations[0].Arguments[2].ToString().Should().Be("Update failed: The animal with id 1 was not found");
        }
    }

}
public class AnimalControllerTestTest5 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly AnimalControllerTest _instance;
    private readonly Mock<ILogger<AnimalController>> _loggerMock;

    public AnimalControllerTestTest5(WebApplicationFactory<Program> factory)
    {
        _instance = new AnimalControllerTest(factory);
        _loggerMock = _instance._loggerMock;
    }

    [Trait("Category", "5 - Crie logs para o método `Delete()`")]
    [Fact(DisplayName = "5 - Crie logs para o método `Delete()`")]
    public async Task DeleteSuccessTest()
    {
        Func<Task> act = () => _instance.DeleteSuccessTest();

        await act.Should().NotThrowAsync<NotImplementedException>();
        await act.Should().NotThrowAsync<XunitException>();

        var invocations = _loggerMock.Invocations.ToList();

        _loggerMock.Invocations.Should().HaveCount(2);

        foreach (var invocation in invocations)
        {
            invocation.Arguments.Should().HaveCount(5);
            invocations[0].Arguments[0].Should().Be(LogLevel.Information);
            invocations[0].Arguments[2].ToString().Should().Be("Delete executed with id 1");
        }
    }

    [Trait("Category", "5 - Crie logs para o método `Delete()`")]
    [Fact(DisplayName = "5 - Crie logs para o método `Delete()`")]
    public async Task DeleteNotFoundTest()
    {
        Func<Task> act = () => _instance.DeleteNotFoundTest();

        await act.Should().NotThrowAsync<NotImplementedException>();
        await act.Should().NotThrowAsync<XunitException>();

        var invocations = _loggerMock.Invocations.ToList();

        _loggerMock.Invocations.Should().HaveCount(2);

        foreach (var invocation in invocations)
        {
            invocation.Arguments.Should().HaveCount(5);
            invocations[0].Arguments[0].Should().Be(LogLevel.Warning);
            invocations[0].Arguments[2].ToString().Should().Be("Delete failed: The animal with id 1 was not found");
        }
    }

}
public class AnimalControllerTestTest6 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly AnimalControllerTest _instance;
    private readonly Mock<ILogger<AnimalController>> _loggerMock;

    public AnimalControllerTestTest6(WebApplicationFactory<Program> factory)
    {
        _instance = new AnimalControllerTest(factory);
        _loggerMock = _instance._loggerMock;
    }

    [Trait("Category", "6 - Crie testes para os logs de erro de todos os métodos do `AnimalController`")]
    [Fact(DisplayName = "6 - Crie testes para os logs de erro de todos os métodos do `AnimalController`")]
    public async Task InternalServerErrorTests()
    {
        Func<Task> act = () => _instance.InternalServerErrorTests();

        await act.Should().NotThrowAsync<NotImplementedException>();
        await act.Should().NotThrowAsync<XunitException>();

        var invocations = _loggerMock.Invocations.ToList();

        _loggerMock.Invocations.Should().HaveCount(10);

        foreach (var invocation in invocations)
        {
            invocation.Arguments.Should().HaveCount(5);
            invocations[0].Arguments[0].Should().Be(LogLevel.Error);
            invocations[0].Arguments[2].ToString().Should().EndWith(" failed");
        }
    }
}
