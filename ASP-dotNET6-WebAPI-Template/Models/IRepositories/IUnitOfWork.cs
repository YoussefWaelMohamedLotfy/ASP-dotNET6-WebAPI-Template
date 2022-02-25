namespace ASP_dotNET6_WebAPI_Template.Models.IRepositories;

public interface IUnitOfWork : IDisposable
{
    // Add Repositories here
    ICustomerRepository Customers { get; }

    Task<int> SaveAsync(CancellationToken cancellationToken);
}
