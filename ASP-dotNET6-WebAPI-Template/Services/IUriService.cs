using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

namespace ASP_dotNET6_WebAPI_Template.Services;

public interface IUriService
{
    Uri GetCustomerUri(int customerId);

    Uri GetAllCustomersUri(PaginationQuery query = null!);
}
