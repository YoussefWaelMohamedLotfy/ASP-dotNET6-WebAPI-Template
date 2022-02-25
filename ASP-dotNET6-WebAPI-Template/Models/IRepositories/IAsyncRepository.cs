namespace ASP_dotNET6_WebAPI_Template.Models.IRepositories;

public interface IAsyncRepository<T, TID> where T : BaseEntity<TID>
{
    Task<T> GetByIdAsync(TID id, CancellationToken cancellationToken);

    Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken, PaginationFilter? filter = null);

    Task<T> AddAsync(T entity, CancellationToken cancellationToken);

    T Update(T entity);

    void Delete(T entity);
}
