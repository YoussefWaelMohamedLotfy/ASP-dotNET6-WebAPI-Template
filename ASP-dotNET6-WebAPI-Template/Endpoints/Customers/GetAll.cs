using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.Customers;

public class GetAll : EndpointBaseSync.WithoutRequest.WithResult<IEnumerable<GetAllCustomersResult>>
{


    /// <summary>
    /// Get All Customer from Database
    /// </summary>
    /// <remarks>
    ///     # Good
    /// </remarks>
    /// <returns>All customers in Database</returns>
    /// <response code="200">A success request</response>
    /// <response code="404">Not Found any Customers</response>
    [HttpGet("api/[namespace]")]
    [ProducesResponseType(typeof(GetAllCustomersResult), 200)]
    [ProducesResponseType(404)]
    public override IEnumerable<GetAllCustomersResult> Handle()
    {
        IEnumerable<GetAllCustomersResult> result = new List<GetAllCustomersResult>()
        {
            new GetAllCustomersResult() { Name = "Ahmed" },
            new GetAllCustomersResult() { Name = "Ahmed1" },
            new GetAllCustomersResult() { Name = "Ahmed2" },
            new GetAllCustomersResult() { Name = "Ahmed3" }
        };
        
        return result;
    }
}
