using CustomerCrud.Core;
using CustomerCrud.Repositories;
using CustomerCrud.Requests;

namespace CustomerCrud.Test;

public class CustomersControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly Mock<ICustomerRepository> _repositoryMock;

    public CustomersControllerTest(WebApplicationFactory<Program> factory)
    {
        _repositoryMock = new Mock<ICustomerRepository>();

        _client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<ICustomerRepository>(st => _repositoryMock.Object);
            });
        }).CreateClient();
    }

    [Fact]
    public async Task GetAllTest()
    {
        var customer = AutoFaker.Generate<Customer>(2);
        _repositoryMock.Setup(x => x.GetAll()).Returns(customer);

        var res = await _client.GetAsync("/controller");
        var content = await res.Content.ReadFromJsonAsync<IEnumerable<Customer>>();

        res.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(customer);

        _repositoryMock.Verify(db => db.GetAll(), Times.Exactly(1));
    }

    [Fact]
    public async Task GetByIdTest()
    {
        var customers = AutoFaker.Generate<Customer>(1);
        _repositoryMock.Setup(x => x.GetById(1)).Returns(customers[0]);
        _repositoryMock.Setup(x => x.GetAll()).Returns(customers);

        var res = await _client.GetAsync("/controller");
        var content = await res.Content.ReadFromJsonAsync<IEnumerable<Customer>>();

        res.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(customers);

        _repositoryMock.Verify(x => x.GetAll(), Times.Exactly(1));
    }

    [Fact]
    public async Task CreateTest()
    {
        var request = AutoFaker.Generate<CustomerRequest>(1);
        var customer = new Customer(1, request[0]);
        _repositoryMock.Setup(x => x.GetNextIdValue()).Returns(1);
        _repositoryMock.Setup(x => x.Create(customer)).Returns(true);
        _repositoryMock.Setup(x => x.GetById(1)).Returns(customer);

        var res = await _client.PostAsJsonAsync("/controller", request[0]);
        var result = await res.Content.ReadFromJsonAsync<Customer>();

        res.StatusCode.Should().Be(HttpStatusCode.Created);
        result.Should().BeEquivalentTo(customer);

        _repositoryMock.Verify(x => x.GetNextIdValue(), Times.Exactly(1));
        _repositoryMock.Verify(x => x.GetById(1), Times.Exactly(1));
    }

    [Fact]
    public async Task UpdateTest()
    {
        var request = AutoFaker.Generate<CustomerRequest>();
        _repositoryMock.Setup(x => x.Update(0, request)).Returns(true);

        var res = await _client.PutAsJsonAsync("/controller/0", request);
        var result = await res.Content.ReadAsStringAsync();

        res.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Should().Be("Customer 1 updated");

        _repositoryMock.Verify(x => x.Update(0, request), Times.Exactly(1));
    }

    [Fact]
    public async Task DeleteTest()
    {
        _repositoryMock.Setup(x => x.Delete(1)).Returns(true);

        var res = await _client.DeleteAsync("/controller/1");

        res.StatusCode.Should().Be(HttpStatusCode.NoContent);

        _repositoryMock.Verify(x => x.Delete(1), Times.Exactly(1));
    }
}