using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.Customers
{
    public class Get : EndpointBaseSync.WithRequest<int>.WithActionResult<GetCustomerResult>
    {

        /// <summary>
        /// Get a customer with the identifier
        /// </summary>
        /// <param name="id" example="4">The ID of Customer to be fetched</param>
        /// <response code="200">Found a Customer</response>
        /// <response code="400">Not Found any with ID</response>
        /// <returns>The Customer Data</returns>
        [HttpGet("api/[namespace]/{id}")]
        public override ActionResult<GetCustomerResult> Handle(int id)
        {
            // Get from DB and return data

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }    

            if (id == 0)
            {
                return NotFound();
            }

            return new GetCustomerResult { ID = id, Name = "Khaled" };
        }
    }
}
