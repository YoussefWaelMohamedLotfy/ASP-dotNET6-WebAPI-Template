using ASP_dotNET6_WebAPI_Template.Endpoints.Customers;
using Swashbuckle.AspNetCore.Filters;

namespace ASP_dotNET6_WebAPI_Template.SwaggerExamples.Responses;

public class GetCustomerResultExample : IExamplesProvider<GetCustomerResult>
{
    public GetCustomerResult GetExamples()
    {
        return new GetCustomerResult { ID = 6, Name = "Hamed", Address = "60 Frisbee Lane", DateOfBirth = DateTime.Now };
    }
}
