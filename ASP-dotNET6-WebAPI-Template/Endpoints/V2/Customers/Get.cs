using Ardalis.ApiEndpoints;
using ASP_dotNET6_WebAPI_Template.Attributes;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.V2.Customers;

public class Get : EndpointBaseSync.WithoutRequest.WithActionResult
{


    /// <summary>
    /// Gets some random customers not in Database
    /// </summary>
    /// <response code="200">Success Response</response>
    /// <response code="401">Unauthorized Response</response>
    /// <returns>Array of random customers</returns>
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "v2.0")]
    [ApiKeyAuthorize]
    [HttpGet("api/[namespace]")]
    //[Cached(30)]
    [HttpCacheIgnore]
    public override ActionResult Handle()
    {
        int count = 7;
        var result = Enumerable.Range(1, count).Select(index => new
        {
            ID = 23 + 6 % 2,
            Name = "Lemmy Andrews",
            Address = $"{count * 3 + 2} Lane Street, DE"
        }).ToArray();

        return Ok(result);
    }
}
