using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;
using Swashbuckle.AspNetCore.Filters;

namespace ASP_dotNET6_WebAPI_Template.Swagger.Examples.Responses;

public class UpdatedCustomerResultExample : IExamplesProvider<UpdatedCustomerResult>
{
    public UpdatedCustomerResult GetExamples()
    {
        return new UpdatedCustomerResult { ID = 3, Name = "Hossam", Address = "567 Lame St", DateOfBirth = DateTimeOffset.Now };
    }
}
