using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.Customers;

public record CreateCustomerResult : CreateCustomerCommand
{
    public int ID { get; init; }
}
