using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;
using ASP_dotNET6_WebAPI_Template.Models;
using ASP_dotNET6_WebAPI_Template.Services;

namespace ASP_dotNET6_WebAPI_Template.Helpers
{
    public class PaginationHelpers
    {
        public static PaginatedResponse<T> CreatePaginatedResponse<T>(IUriService uriService, PaginationFilter filter, List<T> result)
        {
            var nextPage = filter.PageNumber >= 1
                ? uriService.GetAllCustomersUri(new PaginationQuery(filter.PageNumber + 1, filter.PageSize)).ToString()
                : null;

            var previousPage = filter.PageNumber - 1 >= 1
                ? uriService.GetAllCustomersUri(new PaginationQuery(filter.PageNumber - 1, filter.PageSize)).ToString()
                : null;

            return new PaginatedResponse<T>
            {
                Data = result,
                PageNumber = filter.PageNumber >= 1 ? filter.PageNumber : null,
                PageSize = filter.PageSize >= 1 ? filter.PageSize : null,
                NextPage = result.Any() ? nextPage : null,
                PreviousPage = result.Any() ? previousPage : null,
            };
        }
    }
}
