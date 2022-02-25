using Ardalis.ApiEndpoints;
using ASP_dotNET6_WebAPI_Template.Models.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.Customers;

public class GetAll : EndpointBaseAsync.WithoutRequest.WithResult<IEnumerable<GetAllCustomersResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAll(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

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
    public override async Task<IEnumerable<GetAllCustomersResult>> HandleAsync(CancellationToken cancellationToken)
    {
        var result = (await _unitOfWork.Customers.ListAllAsync(cancellationToken))
            .Select(_mapper.Map<GetAllCustomersResult>);
        
        return result;
    }
}
