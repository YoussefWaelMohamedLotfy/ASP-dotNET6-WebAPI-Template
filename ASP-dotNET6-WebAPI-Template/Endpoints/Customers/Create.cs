using Ardalis.ApiEndpoints;
using ASP_dotNET6_WebAPI_Template.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.Customers;

public class Create : EndpointBaseSync.WithRequest<CreateCustomerCommand>.WithActionResult<CreateCustomerResult>
{
    private readonly IMapper _mapper;

    public Create(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    /// <summary>
    /// Creates a new Customer in the database
    /// </summary>
    /// <param name="request"></param>
    /// <returns>The newly created Customer</returns>
    /// <response code="201">Created Success</response>
    /// <response code="400">Bad Request</response>
    [HttpPost("api/[namespace]")]
    [ProducesResponseType(typeof(CreateCustomerResult), 201)]
    public override ActionResult<CreateCustomerResult> Handle([FromBody] CreateCustomerCommand request)
    {
        Customer newCustomer = _mapper.Map<Customer>(request);

        // Add in Repo and Save

        var result = _mapper.Map<CreateCustomerResult>(newCustomer);
        return CreatedAtRoute("Customers_Get", new { id = result.ID }, result);
    }
}
