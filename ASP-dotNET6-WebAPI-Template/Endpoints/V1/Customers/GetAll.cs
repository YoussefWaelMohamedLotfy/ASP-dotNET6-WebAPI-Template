using Ardalis.ApiEndpoints;
using ASP_dotNET6_WebAPI_Template.Helpers;
using ASP_dotNET6_WebAPI_Template.Models;
using ASP_dotNET6_WebAPI_Template.Models.IRepositories;
using ASP_dotNET6_WebAPI_Template.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

public class GetAll : EndpointBaseAsync.WithRequest<PaginationQuery>.WithResult<PaginatedResponse<GetAllCustomersResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUriService _uriService;

    public GetAll(IUnitOfWork unitOfWork, IMapper mapper, IUriService uriService)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _uriService = uriService ?? throw new ArgumentNullException(nameof(uriService));
    }

    /// <summary>
    /// Get All Customer from Database
    /// </summary>
    /// <remarks>
    ///     # A paginated Endpoint for fetching
    ///     ---
    ///     **Check it out**
    /// </remarks>
    /// <param name="query">The pagination query</param>
    /// <param name="cancellationToken"></param>
    /// <returns>All customers in Database</returns>
    /// <response code="200">A success request</response>
    /// <response code="404">Not Found any Customers</response>
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1.0")]
    [HttpGet("api/[namespace]")]
    public override async Task<PaginatedResponse<GetAllCustomersResult>> HandleAsync([FromQuery] PaginationQuery query, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<PaginationFilter>(query);
        var customersInDb = await _unitOfWork.Customers.ListAllAsync(cancellationToken, filter);
        var result = _mapper.Map<List<GetAllCustomersResult>>(customersInDb);

        if (filter is null || filter.PageNumber < 1 || filter.PageSize < 1)
        {
            return new PaginatedResponse<GetAllCustomersResult>(result);
        }

        var response = PaginationHelpers.CreatePaginatedResponse(_uriService, filter, result);
        return response;
    }
}
