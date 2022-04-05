using Ardalis.ApiEndpoints;
using ASP_dotNET6_WebAPI_Template.Models.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerCommand>.WithActionResult<UpdatedCustomerResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Update(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Updates a customer in database
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <response code="200">Updated Successfully</response>
    /// <response code="404">Not Found</response>
    [ApiExplorerSettings(GroupName = "v1.0")]
    [HttpPut("api/[namespace]")]
    public override async Task<ActionResult<UpdatedCustomerResult>> HandleAsync([FromBody] UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var customerInDb = await _unitOfWork.Customers.GetByIdAsync(request.ID, cancellationToken);

        if (customerInDb is null)
            return NotFound();

        _mapper.Map(request, customerInDb);
        _unitOfWork.Customers.Update(customerInDb);
        await _unitOfWork.SaveAsync(cancellationToken);

        var result = _mapper.Map<UpdatedCustomerResult>(customerInDb);
        return result;
    }
}
