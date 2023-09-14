using auth_api.Test;

namespace auth_api.Test.Test;

public class UserTestTest
{
  TestingWebAppFactory<Program> _factory = new TestingWebAppFactory<Program>();

  [Trait("Category", "Crie um endpoint de registro para o usuário")]
  [Fact(DisplayName = "ShouldReturnUserData deve ser executado com sucesso com o input de sucesso")]
  public async Task TestShouldReturnUserData()
  {
    UserTest instance = new(_factory);
    Func<Task> task = async () => await instance.ShouldReturnUserData();
    await task.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
    await task.Should().NotThrowAsync<NotImplementedException>();
  }
}
public class UserTestTest2
{

  TestingWebAppFactory<Program> _factory = new TestingWebAppFactory<Program>();

  [Trait("Category", "Crie um endpoint de registro para a listagem de usuários")]
  [Fact(DisplayName = "ShouldReturnAllUsers deve ser executado com sucesso com o input de sucesso")]
  public async Task TestShouldReturnAllUsers()
  {
    UserTest instance = new(_factory);
    Func<Task> task = async () => await instance.ShouldReturnAllUsers();
    await task.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
    await task.Should().NotThrowAsync<NotImplementedException>();
  }
}
