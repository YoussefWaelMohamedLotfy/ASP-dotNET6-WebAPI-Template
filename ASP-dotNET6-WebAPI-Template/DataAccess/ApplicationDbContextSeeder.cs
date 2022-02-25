using ASP_dotNET6_WebAPI_Template.Models;
using Bogus;
using static Bogus.DataSets.Name;

namespace ASP_dotNET6_WebAPI_Template.DataAccess;

public class ApplicationDbContextSeeder
{
    public static async Task SeedAsync(ApplicationDbContext dbContext, ILogger<ApplicationDbContextSeeder> logger)
    {
        if (!dbContext.Customers.Any())
        {
            var fakeCustomers = new Faker<Customer>()
                .RuleFor(c => c.Name, f => f.Name.FullName(f.PickRandom<Gender>()))
                .RuleFor(c => c.Address, f => f.Address.StreetAddress())
                .RuleFor(c => c.DateOfBirth, f => f.Date.PastOffset());

            await dbContext.Customers.AddRangeAsync(fakeCustomers.Generate(7));
        }

        await dbContext.SaveChangesAsync();
        logger.LogInformation("Completed Seeding of {DbContextName}", typeof(ApplicationDbContext).Name);
    }

}
