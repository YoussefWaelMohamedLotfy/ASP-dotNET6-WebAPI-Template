using ASP_dotNET6_WebAPI_Template.Endpoints.Customers;
using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;
using ASP_dotNET6_WebAPI_Template.Models;
using AutoMapper;

namespace ASP_dotNET6_WebAPI_Template;

public class AutoMappingConfig : Profile
{
    public AutoMappingConfig()
    {
        // Commands to Entities Mapping
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();

        CreateMap<PaginationQuery, PaginationFilter>();


        // Entities to Results Mapping
        CreateMap<Customer, GetCustomerResult>();
        CreateMap<Customer, GetAllCustomersResult>();
        CreateMap<Customer, CreateCustomerResult>();
        CreateMap<Customer, UpdatedCustomerResult>();
    }
}
