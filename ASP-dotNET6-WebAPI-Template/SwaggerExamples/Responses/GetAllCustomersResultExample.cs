using ASP_dotNET6_WebAPI_Template.Endpoints.Customers;
using Swashbuckle.AspNetCore.Filters;

namespace ASP_dotNET6_WebAPI_Template.SwaggerExamples.Responses
{
    public class GetAllCustomersResultExample : IExamplesProvider<GetAllCustomersResult>
    {
        public GetAllCustomersResult GetExamples()
        {
            return new GetAllCustomersResult { Name = "Khaled", Address = "3 Lane Street", DateOfBirth = DateTime.Now };
        }
    }
}
