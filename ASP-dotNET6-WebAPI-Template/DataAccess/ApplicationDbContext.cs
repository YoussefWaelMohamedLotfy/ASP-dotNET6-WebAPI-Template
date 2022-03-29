using ASP_dotNET6_WebAPI_Template.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_dotNET6_WebAPI_Template.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; } = default!;
}
