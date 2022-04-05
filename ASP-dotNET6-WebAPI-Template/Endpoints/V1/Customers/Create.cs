using Ardalis.ApiEndpoints;
using ASP_dotNET6_WebAPI_Template.Endpoints.Customers;
using ASP_dotNET6_WebAPI_Template.Models;
using ASP_dotNET6_WebAPI_Template.Models.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

public class Create : EndpointBaseAsync.WithRequest<CreateCustomerCommand>.WithActionResult<CreateCustomerResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Create(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Creates a new Customer in the database
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The newly created Customer</returns>
    /// <response code="201">Created Success</response>
    /// <response code="400">Bad Request</response>
    [ApiExplorerSettings(GroupName = "v1.0")]
    [HttpPost("api/[namespace]")]
    [ProducesResponseType(typeof(CreateCustomerResult), 201)]
    public override async Task<ActionResult<CreateCustomerResult>> HandleAsync([FromBody] CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer newCustomer = _mapper.Map<Customer>(request);
        await _unitOfWork.Customers.AddAsync(newCustomer, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        var result = _mapper.Map<CreateCustomerResult>(newCustomer);
        return CreatedAtRoute("Customers_Get", new { id = result.ID }, result);
    }
}
