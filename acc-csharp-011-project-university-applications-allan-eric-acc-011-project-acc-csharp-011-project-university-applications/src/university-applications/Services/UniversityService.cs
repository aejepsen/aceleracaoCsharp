namespace university_applications.Services
{
  public class UniversityService : IUniversityService
  {
    private readonly HttpClient _client;
    private string _baseUrl = "http://universities.hipolabs.com";
    public UniversityService(HttpClient client)
    {
      _client = client;
      _client.BaseAddress = new Uri(_baseUrl);
    }

    public async Task<object> FindUniversity(string name, string country)
    {
      var res = await _client.GetAsync($"search?name={name}&country={country}");
      if (!res.IsSuccessStatusCode)
      {
        return default;
      }
      var resJson = await res.Content.ReadFromJsonAsync<object>();
      return resJson;
    }

    public async Task<object> FindUniversity(string country)
    {
      var res = await _client.GetAsync($"search?country={country}");
      if (!res.IsSuccessStatusCode)
      {
        return default;
      }
      var resJson = await res.Content.ReadFromJsonAsync<object>();
      return resJson;
    }
  }
}