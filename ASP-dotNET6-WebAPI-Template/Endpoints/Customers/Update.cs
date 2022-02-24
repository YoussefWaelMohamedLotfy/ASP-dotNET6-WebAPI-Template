using Ardalis.ApiEndpoints;
using ASP_dotNET6_WebAPI_Template.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP_dotNET6_WebAPI_Template.Endpoints.Customers
{
    public class Update : EndpointBaseSync.WithRequest<UpdateCustomerCommand>.WithActionResult<UpdatedCustomerResult>
    {
        private readonly IMapper _mapper;

        public Update(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Updates a customer in database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Updated Successfully</response>
        /// <response code="404">Not Found</response>
        [HttpPut("api/[namespace]")]
        public override ActionResult<UpdatedCustomerResult> Handle([FromBody] UpdateCustomerCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (request.ID == 0)
                return NotFound();

            Customer customerinDb = new();
            _mapper.Map(request, customerinDb);

            // Update and save

            var result = _mapper.Map<UpdatedCustomerResult>(customerinDb);
            return result;
        }
    }
}
