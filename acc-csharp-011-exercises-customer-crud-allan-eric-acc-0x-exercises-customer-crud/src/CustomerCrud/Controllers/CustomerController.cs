using Microsoft.AspNetCore.Mvc;
using CustomerCrud.Core;
using CustomerCrud.Requests;
using CustomerCrud.Repositories;

namespace CustomerCrud.Controllers;

[ApiController]
[Route("/controller")]

public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetAll()
    {
        var customers = _customerRepository.GetAll();
        return StatusCode(200, customers);
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetById(int id)
    {
        var customer = _customerRepository.GetById(id);
        if (customer == null)
        {
            return StatusCode(404);
        }
        return StatusCode(200);
    }

   [HttpPost]
    public ActionResult Create(CustomerRequest request)
    {
         var id = _customerRepository.GetNextIdValue();
         var customer = new Customer
         (
            id,
            request
         ); 
         _customerRepository.Create(customer);
         var created = _customerRepository.GetById(id);
         return StatusCode(201, created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, CustomerRequest request)
    {
        var customer = _customerRepository.Update(id, request);
        if (customer == false)
        {
           return StatusCode(404,"Customer not found");
        }
        return StatusCode(200, $"Customer {id} updated");
    }

[HttpDelete("{id}")]
public ActionResult Delete(int id)
{
    var customer = _customerRepository.Delete(id);
    if (customer == false)
    {
        return StatusCode(404, "Customer not found");
    }
    return StatusCode(204);
}
}