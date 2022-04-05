using Ardalis.ApiEndpoints;
using ASP_dotNET6_WebAPI_Template.Attributes;
using ASP_dotNET6_WebAPI_Template.Models.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetCustomerResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Get(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Get a customer with the identifier
    /// </summary>
    /// <param name="id" example="4">The ID of Customer to be fetched</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Found a Customer</response>
    /// <response code="400">Not Found any with ID</response>
    /// <returns>The Customer Data</returns>
    [ApiExplorerSettings(GroupName = "v1.0")]
    [HttpGet("api/[namespace]/{id}", Name = "[namespace]_[controller]")]
    [Cached(200)]
    public override async Task<ActionResult<GetCustomerResult>> HandleAsync(int id, CancellationToken cancellationToken)
    {
        // Get from DB and return data
        var customerInDb = await _unitOfWork.Customers.GetByIdAsync(id, cancellationToken);

        if (customerInDb is null)
        {
            return NotFound();
        }

        var result = _mapper.Map<GetCustomerResult>(customerInDb);

        return result;
    }
}
