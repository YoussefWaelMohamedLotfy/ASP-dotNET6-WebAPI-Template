using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.Customers
{
    public class Delete : EndpointBaseSync.WithRequest<int>.WithActionResult
    {

        /// <summary>
        /// Deletes a customer with ID
        /// </summary>
        /// <param name="id" example="6">Identifier of customer to be deleted</param>
        /// <returns></returns>
        /// <response code="204">No Content Success</response>
        /// <response code="404">Not Found ID</response>
        [HttpDelete("api/[namespace]/{id}")]
        public override ActionResult Handle(int id)
        {
            if (id == 0)
                return NotFound();

            // Delete from repo and save

            return NoContent();
        }
    }
}
