using Xunit;
using FluentAssertions;
using student_validation.Models;
using System.Collections.Generic;
using student_validation.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace student_validation.Test.Test;

public class TestTestStudentApi : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _clientFactory;
    public TestTestStudentApi(WebApplicationFactory<Program> factory)
    {
        _clientFactory = factory;
    }

    [Trait("Category", "1 - Criar a validação para o model Student e seu teste")]
    [Theory(DisplayName = "PostMethods_ShouldReturnValidationError deve ser executado com sucesso com entradas corretas")]
    [MemberData(nameof(PostMethods_ShouldReturnValidationError_Data))]  
    public void TestSucessPostMethods_ShouldReturnValidationError(Student student, ErrorObject resultExpected)
    {
        TestStudentApi instance = new(_clientFactory);
        Action act = () => instance.PostMethods_ShouldReturnValidationError(student, resultExpected);
        act.Should().NotThrow<Xunit.Sdk.XunitException>();
        act.Should().NotThrow<NotImplementedException>();
    }

    [Trait("Category", "1 - Criar a validação para o model Student e seu teste")]
    [Fact(DisplayName = "Registration deve ser a chave primária de student")]
    public void TestPrimaryKey()
    {
        var contextOptions = new DbContextOptionsBuilder<SchoolContextTest>()
            .UseInMemoryDatabase("VideoPortalContext")
            .Options;
        SchoolContextTest testContext = new(contextOptions);
        DbSet<Student> set = testContext.Set<Student>();
        var property = set.EntityType.FindProperty("Registration");
        property.IsKey().Should().BeTrue();
    }


    public static TheoryData<Student, ErrorObject> PostMethods_ShouldReturnValidationError_Data = new()
    {
        {
            new Student { Registration = null, Name = "Incorrect Name Incorrect Name Incorrect Name Incorrect Name Incorrect Name Incorrect Name Incorrect Name Incorrect Name Incorrect Name", Email = "incorrectmail"},
            new ErrorObject
            {
                Status = 400,
                Errors = new Dictionary<string, List<string>>
                {
                    { "Registration", new List<string> { "A matricula é obrigatória" } },
                    { "Name", new List<string> { "Nome pode ter no máximo 50 caracteres" } },                    
                    { "Email", new List<string> { "O email deve ter o formato correto" } }
                }
            }
        },
        {
            new Student { Registration = null, Name = "CorrectName", Email = "incorrect mail"},
            new ErrorObject
            {
                Status = 400,
                Errors = new Dictionary<string, List<string>>
                {
                    { "Registration", new List<string> { "A matricula é obrigatória" } },
                    { "Email", new List<string> { "O email deve ter o formato correto" } }
                }
            }
        },
        {
            new Student { Registration = null, Name = "CorrectName", Email = "correct@gmail.com"},
            new ErrorObject
            {
                Status = 400,
                Errors = new Dictionary<string, List<string>>
                {
                    { "Registration", new List<string> { "A matricula é obrigatória" } }
                }
            }
        }
    };


}