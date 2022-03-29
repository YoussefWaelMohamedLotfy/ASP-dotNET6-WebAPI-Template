namespace ASP_dotNET6_WebAPI_Template.Models;

public class Customer : BaseEntity<int>
{
    public string Name { get; set; } = default!;

    public string Address { get; set; } = default!;

    public DateTimeOffset DateOfBirth { get; set; }
}
