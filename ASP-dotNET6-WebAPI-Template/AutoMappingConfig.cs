using ASP_dotNET6_WebAPI_Template.Endpoints.Customers;
using ASP_dotNET6_WebAPI_Template.Models;
using AutoMapper;

namespace ASP_dotNET6_WebAPI_Template
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            // Commands to Entities Mapping
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();


            // Entities to Results Mapping
            CreateMap<Customer, GetCustomerResult>();
            CreateMap<Customer, CreateCustomerResult>();
            CreateMap<Customer, UpdatedCustomerResult>();
        }
    }
}
