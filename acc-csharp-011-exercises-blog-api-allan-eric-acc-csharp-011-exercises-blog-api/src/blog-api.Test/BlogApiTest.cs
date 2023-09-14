namespace blog_api.Test;

using blog_api.Models;

public class BlogApiTest
{ 
  
  [Theory]
  [InlineData("Title 1", "Content 1", "Author 1", "Author 1", "author@email.com")]
  public void ShouldCreateAPost(string title, string content, string authorName, string authorAbout, string authorEmail)
  {
    var post = new Post
    {
      Title = title,
      Content = content,
      Author = new Author
      {
        Name = authorName,
        About = authorAbout,
        Email = authorEmail
      }
    };

    var context = new BlogTestContext();
    var repository = new BlogRepository(context);

    repository.Add(post);
    repository.Get<Post>(post.PostId).Should().Be(post);


  }

  [Theory]
  [InlineData(1)]
  public void ShouldDeleteAuthor(int postId)
  {
        var post = new Post
        {
            PostId = postId
        };

        var context = new BlogTestContext();
        _ = new BlogRepository(context);

        context.Posts.Remove(post);


    }
}
