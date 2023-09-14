using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using student_validation.Models;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using student_validation.ResponseModels;
using Microsoft.Extensions.DependencyInjection;

namespace student_validation.Test;

public class TestStudentApi : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly HttpClient _client;
  public TestStudentApi(WebApplicationFactory<Program> factory)
  {
    _client = factory.WithWebHostBuilder(builder =>
    {
      builder.ConfigureServices(services =>
          {
            services.AddDbContext<SchoolContext>(options =>
                {
                  options.UseInMemoryDatabase("StudentDb");
                });
          });
    }).CreateClient();
  }

  [Theory]
  [MemberData(nameof(PostMethods_ShouldReturnValidationError_Data))]
  public async void PostMethods_ShouldReturnValidationError(Student student, ErrorObject resultExpected)
  {
    var res = await _client.PostAsync("/api/Student", new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json"));

    res.StatusCode.Should().Be(HttpStatusCode.BadRequest);

    JsonSerializer.Deserialize<ErrorObject>(await res.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).Should().BeEquivalentTo(resultExpected);

  }

  public static TheoryData<Student, ErrorObject> PostMethods_ShouldReturnValidationError_Data = new()
    {
        {
            new Student {
                Name = "antonio jose da silva marcondes pereira de souza e silva",
                Email = "alo.ola.ola.com",
             },
            new ErrorObject
            {
                Status = 400,
                Errors = new Dictionary<string, List<string>>
                {
                    {"Registration", new List<string>{"A matricula é obrigatória"}},
                    { "Name",new List<string> { "Nome pode ter no máximo 50 caracteres" }},
                    { "Email", new List<string> { "O email deve ter o formato correto" }},

                }
            }
        }
};
}
