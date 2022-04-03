using ASP_dotNET6_WebAPI_Template.Endpoints.Customers;
using Swashbuckle.AspNetCore.Filters;

namespace ASP_dotNET6_WebAPI_Template.Swagger.Examples.Responses;

public class CreateCustomerResultExample : IExamplesProvider<CreateCustomerResult>
{
    public CreateCustomerResult GetExamples()
    {
        return new CreateCustomerResult { ID = 12 ,Name = "Mahmoud", Address = "23 Abbey Lane", DateOfBirth = DateTimeOffset.UtcNow};
    }
}
