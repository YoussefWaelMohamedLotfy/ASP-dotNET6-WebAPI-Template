namespace ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;

public class GetAllCustomersResult
{
    public int ID { get; set; }

    public string Name { get; set; } = default!;

    public string Address { get; set; } = default!;

    public DateTimeOffset DateOfBirth { get; set; }
}
