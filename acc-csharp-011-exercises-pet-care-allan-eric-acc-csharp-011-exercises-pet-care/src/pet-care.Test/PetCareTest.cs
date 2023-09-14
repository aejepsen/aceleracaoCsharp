using System.Text;

namespace pet_care.Test;

public class PetCareTest : IClassFixture<TestingWebAppFactory<Program>>
{
  private readonly HttpClient _client;

  public PetCareTest(TestingWebAppFactory<Program> factory)
      => _client = factory.CreateClient();

  [Fact]
  public async Task ShouldCreateAnAppointment()
  {
    var jsonCreated = "{\"vetId\":1,\"vet\":{\"vetId\":1,\"name\":\"dr. vet\",\"address\":\"adress vet\",\"phone\":\"9999-9999\",\"email\":\"vet@vet.com\",\"specialtyId\":1,\"specialty\":{\"specialtyId\":1,\"name\":\"vet\"}},\"petId\":1,\"pet\":{\"petId\":1,\"name\":\"strinname pet\",\"description\":\"pet description\",\"age\":1,\"breedId\":1,\"breed\":{\"breedId\":1,\"name\":\"breed name\",\"description\":\"breed description\"}}}";

    var stringContent = new StringContent(jsonCreated, Encoding.UTF8, "application/json");
    var resultPost = await _client.PostAsync("/api/Appointment", stringContent);
    resultPost.StatusCode.Should().Be((System.Net.HttpStatusCode)200);
  }
}