using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;
using Swashbuckle.AspNetCore.Filters;

namespace ASP_dotNET6_WebAPI_Template.Swagger.Examples.Requests;

public class CreateCustomerCommandExample : IExamplesProvider<CreateCustomerCommand>
{
    public CreateCustomerCommand GetExamples()
    {
        return new CreateCustomerCommand { Name = "Mahmoud", Address = "23 Abbey Lane", DateOfBirth = DateTimeOffset.UtcNow};
    }
}
