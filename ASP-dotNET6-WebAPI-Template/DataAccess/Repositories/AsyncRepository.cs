using ASP_dotNET6_WebAPI_Template.Models;
using ASP_dotNET6_WebAPI_Template.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ASP_dotNET6_WebAPI_Template.DataAccess.Repositories;

public class AsyncRepository<T, TID> : IAsyncRepository<T, TID> where T : BaseEntity<TID>
{
    protected readonly ApplicationDbContext _context;
    private readonly DbSet<T> _db;

    public AsyncRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _db = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _db.AddAsync(entity, cancellationToken);
        return entity;
    }

    public void Delete(T entity)
    {
        _db.Remove(entity);
    }

    public async Task<T> GetByIdAsync(TID id, CancellationToken cancellationToken)
    {
        return await _db.SingleOrDefaultAsync(x => x.ID.Equals(id), cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken, PaginationFilter? filter = null)
    {
        if (filter is null)
        {
            return await _db.ToListAsync(cancellationToken);
        }

        int skipNumber = (filter.PageNumber - 1) * filter.PageSize;
        return await _db.Skip(skipNumber).Take(filter.PageSize).ToListAsync(cancellationToken);
    }

    public T Update(T entity)
    {
        _db.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;

        return entity;
    }
}
