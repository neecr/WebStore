using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    [Route("/getCustomerById/{customerId:int}")]
    public IActionResult GetCustomer(int customerId)
    {
        var customer = _customerService.GetCustomer(customerId);
        return Ok(customer);
    }
    
    [HttpGet]
    [Route("/getCustomers")]
    public IActionResult GetCustomers()
    {
        var customer = _customerService.GetCustomers();
        return Ok(customer);
    }

    [HttpPost]
    [Route("/createCustomer")]
    public IActionResult CreateCustomer(CustomerRequestDto customerRequestDto)
    {
        var newCustomer = _customerService.CreateCustomer(customerRequestDto);
        return Ok(newCustomer);
    }

    [HttpPut]
    [Route("/updateCustomer/{customerId:int}")]
    public IActionResult UpdateCustomer(int customerId, CustomerUpdateDto customerUpdateDto)
    {
        var updatedCustomer = _customerService.UpdateCustomer(customerId, customerUpdateDto);
        return Ok(updatedCustomer);
    }

    [HttpDelete]
    [Route("/deleteCustomer/{customerId:int}")]
    public IActionResult DeleteCustomer(int customerId)
    {
        _customerService.DeleteCustomer(customerId);
        return NoContent();
    }
}