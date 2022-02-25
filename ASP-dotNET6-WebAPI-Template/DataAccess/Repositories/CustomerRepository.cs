using ASP_dotNET6_WebAPI_Template.Models;
using ASP_dotNET6_WebAPI_Template.Models.IRepositories;

namespace ASP_dotNET6_WebAPI_Template.DataAccess.Repositories;

public class CustomerRepository : AsyncRepository<Customer, int>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
    }
}
