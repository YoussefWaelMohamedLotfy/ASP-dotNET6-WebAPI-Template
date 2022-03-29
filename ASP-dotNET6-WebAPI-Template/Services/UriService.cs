using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;
using Microsoft.AspNetCore.WebUtilities;

namespace ASP_dotNET6_WebAPI_Template.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllCustomersUri(PaginationQuery query = null!)
        {
            Uri uri = new(_baseUri);

            if (query is null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageNumber", query.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", query.PageSize.ToString());

            return new Uri(modifiedUri);
        }

        public Uri GetCustomerUri(int customerId)
        {
            return new Uri($"{_baseUri}/api/Customers/{customerId}");
        }
    }
}
