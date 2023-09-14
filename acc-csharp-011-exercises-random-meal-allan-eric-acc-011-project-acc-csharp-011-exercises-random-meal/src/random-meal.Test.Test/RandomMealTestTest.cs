namespace random_meal.Test.Test;

public class RandomMealTestTest
{
  TestingWebAppFactory<Program> _factory = new TestingWebAppFactory<Program>();

  [Trait("Category", "1 - Complete a implementação e Teste o seu endpoint")]
  [Fact(DisplayName = "ShouldMakeARequest deve ser executado com sucesso com o input de sucesso")]
  public async Task TestShouldMakeARequest()
  {
    RandomMealTest instance = new(_factory);
    Func<Task> task = async () => await instance.ShouldMakeARequest();
    await task.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
    await task.Should().NotThrowAsync<NotImplementedException>();
  }

}