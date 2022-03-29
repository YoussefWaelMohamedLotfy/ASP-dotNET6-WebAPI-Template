namespace ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

public record UpdatedCustomerResult : UpdateCustomerCommand
{
    public string Address { get; init; } = default!;

    public DateTimeOffset DateOfBirth { get; init; }
}
