using System.Net;
using Microsoft.Data.SqlClient;

namespace BookingApi.Test.Test;

public class SecondReqTest
{
    static readonly HttpClient client = new HttpClient();

    [Trait("Category", "2 - Conteinerizar a aplicação")]
    [Fact(DisplayName = "A rota de GET da API deve funcionar")]
    public void GetBooking_ShouldReturnOk()
    {
        var response = client.GetAsync("http://localhost:5000/api/booking").Result;
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
