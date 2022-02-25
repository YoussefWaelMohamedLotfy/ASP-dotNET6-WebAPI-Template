using ASP_dotNET6_WebAPI_Template.DataAccess.Repositories;
using ASP_dotNET6_WebAPI_Template.Models.IRepositories;

namespace ASP_dotNET6_WebAPI_Template.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public ICustomerRepository Customers { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        Customers = new CustomerRepository(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
