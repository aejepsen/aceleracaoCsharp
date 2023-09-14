namespace pet_care.Test.Test;

public class PetCareTestTest
{
  TestingWebAppFactory<Program> _factory = new TestingWebAppFactory<Program>();

  [Trait("Category", "1 - Criar a classe Appointment e seu teste")]
  [Fact(DisplayName = "ShouldCreateAnAppointment deve ser executado com sucesso com o input de sucesso")]
  public async Task TestShouldCreateAnAppointment()
  {
    PetCareTest instance = new(_factory);
    Func<Task> task = async () => await instance.ShouldCreateAnAppointment();
    await task.Should().NotThrowAsync<Xunit.Sdk.XunitException>();
    await task.Should().NotThrowAsync<NotImplementedException>();
  }
}