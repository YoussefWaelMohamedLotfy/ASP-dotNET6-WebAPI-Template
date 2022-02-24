﻿using ASP_dotNET6_WebAPI_Template.Endpoints.Customers;
using Swashbuckle.AspNetCore.Filters;

namespace ASP_dotNET6_WebAPI_Template.SwaggerExamples.Responses
{
    public class GetAllCustomersResultExample : IExamplesProvider<IEnumerable<GetAllCustomersResult>>
    {
        public IEnumerable<GetAllCustomersResult> GetExamples()
        {
            yield return new GetAllCustomersResult { Name = "Khaled", Address = "3 Lane Street", DateOfBirth = DateTime.Now };
            yield return new GetAllCustomersResult { Name = "Omar", Address = "5 Lane Street", DateOfBirth = DateTime.Now };
        }
    }
}
