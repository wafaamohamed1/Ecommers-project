using Ecommers.Domain.Entites;
using Ecommers.Domain.commov;
using Commers.Infrastruser.Data.configration;
using Microsoft.EntityFrameworkCore;

namespace Commers.Infrastruser.Data.Repositories;

internal sealed class GenericRepository<TEntity>(StoreDbContext context) : IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _entities = context.Set<TEntity>();

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _entities
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _entities.FindAsync([id], cancellationToken).AsTask();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _entities.AddAsync(entity, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _entities.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _entities.Remove(entity);
    }
}
