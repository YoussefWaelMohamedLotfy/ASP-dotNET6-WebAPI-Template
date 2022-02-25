namespace ASP_dotNET6_WebAPI_Template.DataAccess
{
    public class ApplicationDbContextSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext, ILogger<ApplicationDbContextSeeder> logger)
        {
            if (!dbContext.Customers.Any())
            {

            }

            await dbContext.SaveChangesAsync();
            logger.LogInformation("Completed Seeding of {DbContextName}", typeof(ApplicationDbContext).Name);
        }

    }
}
