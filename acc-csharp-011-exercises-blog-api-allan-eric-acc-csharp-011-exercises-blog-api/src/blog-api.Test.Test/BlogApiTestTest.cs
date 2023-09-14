using blog_api.Test;

namespace blog_api.Test.Test;

public class BlogApiTestTestReq1
{
  [Trait("Category", "1 - Complete a classe `BlogContext` para acessar uma fonte de dados")]
  [Theory(DisplayName = "ShouldCreateAPost deve ser executado com sucesso com o input de sucesso")]
  [InlineData("Title 1", "Content 1", "Author 1", "Author 1", "author@email.com")]
  [InlineData("Title 2", "Another Content", "Author 10", "About Author", "author@email.com")]
  public void TestShouldCreateAPostSucess(string title, string content, string authorName, string authorAbout, string authorEmail)
  {
    BlogApiTest instance = new();
    Action act = () => instance.ShouldCreateAPost(title, content, authorName, authorAbout, authorEmail);
    act.Should().NotThrow<Xunit.Sdk.XunitException>();
    act.Should().NotThrow<NotImplementedException>();
  }
}

public class BlogApiTestTestReq2
{
  [Trait("Category", "2 - Crie um crud para a criação de posts no blog")]
  [Theory(DisplayName = "ShouldCreateAPost deve ser executado com sucesso com o input de falha")]
  [InlineData("Title 1", null, "Author 1", "Author 1", "author@email.com")]
  [InlineData("Title 2", "Another Content", "Author 10", null, "author@email.com")]
  public void TestShouldCreateAPostException(string title, string content, string authorName, string authorAbout, string authorEmail)
  {
    BlogApiTest instance = new();
    Action act = () => instance.ShouldCreateAPost(title, content, authorName, authorAbout, authorEmail);
    act.Should().Throw<Microsoft.EntityFrameworkCore.DbUpdateException>();
    act.Should().NotThrow<NotImplementedException>();
  }
}

public class BlogApiTestTestReq3
{
  [Trait("Category", "3 -  Complete a classe `BlogTestContext` para testar nossa fonte de dados")]
  [Theory(DisplayName = "TestShouldDeleteAuthor deve ser executado com sucesso com o input de sucesso")]
  [InlineData(1)]  
  public void TestShouldDeleteAuthor(int postId)
  {
    BlogApiTest instance = new();
    Action act = () => instance.ShouldDeleteAuthor(postId);
    act.Should().NotThrow<System.NullReferenceException>();
    act.Should().NotThrow<NotImplementedException>();
  }
}
