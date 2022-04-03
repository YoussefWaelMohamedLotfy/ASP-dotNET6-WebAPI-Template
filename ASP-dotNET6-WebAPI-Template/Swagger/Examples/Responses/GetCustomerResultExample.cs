using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;
using Swashbuckle.AspNetCore.Filters;

namespace ASP_dotNET6_WebAPI_Template.Swagger.Examples.Responses;

public class GetCustomerResultExample : IExamplesProvider<GetCustomerResult>
{
    public GetCustomerResult GetExamples()
    {
        return new GetCustomerResult { ID = 6, Name = "Hamed", Address = "60 Frisbee Lane", DateOfBirth = DateTime.Now };
    }
}
