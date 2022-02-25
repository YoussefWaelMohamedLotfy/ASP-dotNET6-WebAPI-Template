using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;
using Swashbuckle.AspNetCore.Filters;

namespace ASP_dotNET6_WebAPI_Template.SwaggerExamples.Requests;

public class UpdateCustomerCommandExample : IExamplesProvider<UpdateCustomerCommand>
{
    public UpdateCustomerCommand GetExamples()
    {
        return new UpdateCustomerCommand { ID = 3, Name = "Hany" };
    }
}
