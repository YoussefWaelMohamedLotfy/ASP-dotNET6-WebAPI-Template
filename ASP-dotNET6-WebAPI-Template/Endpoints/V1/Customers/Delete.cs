using Ardalis.ApiEndpoints;
using ASP_dotNET6_WebAPI_Template.Models.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly IUnitOfWork _unitOfWork;

    public Delete(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    /// <summary>
    /// Deletes a customer with ID
    /// </summary>
    /// <param name="id" example="6">Identifier of customer to be deleted</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <response code="204">No Content Success</response>
    /// <response code="404">Not Found ID</response>
    [ApiExplorerSettings(GroupName = "v1.0")]
    [HttpDelete("api/[namespace]/{id}")]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var customerInDb = await _unitOfWork.Customers.GetByIdAsync(id, cancellationToken);

        if (customerInDb is null)
            return NotFound(id);

        _unitOfWork.Customers.Delete(customerInDb);
        await _unitOfWork.SaveAsync(cancellationToken);

        return NoContent();
    }
}
