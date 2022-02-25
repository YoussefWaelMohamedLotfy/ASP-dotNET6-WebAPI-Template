using ASP_dotNET6_WebAPI_Template.Models.IRepositories;

namespace ASP_dotNET6_WebAPI_Template.Models
{
    public interface IUnitOfWork : IDisposable
    {
        // Add Repositories here
        ICustomerRepository Customers { get; }

        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
