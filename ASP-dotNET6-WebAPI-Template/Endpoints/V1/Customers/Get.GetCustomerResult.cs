namespace ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

public record GetCustomerResult
{
    public int ID { get; init; }

    public string Name { get; init; } = default!;

    public string Address { get; init; } = default!;

    public DateTimeOffset DateOfBirth { get; init; }
}
