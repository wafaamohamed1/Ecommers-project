using Ecommers.Domain.Entites;
using Ecommers.Domain.commov;
using Ecommers.Domain.commov.contractic;
using Commers.Infrastruser.Data.configration;
using Commers.Infrastruser.Data.Repositories;

namespace Commers.Infrastruser.Data.UnitOfWork;

public sealed class UnitOfWork(StoreDbContext context) : IUnitOfWork
{
    private readonly Dictionary<Type, object> _repositories = [];

    public IGenericRepository<TEntity> GetRepository<TEntity>()
        where TEntity : BaseEntity
    {
        var entityType = typeof(TEntity);

        if (_repositories.TryGetValue(entityType, out var repository))
        {
            return (IGenericRepository<TEntity>)repository;
        }

        var newRepository = new GenericRepository<TEntity>(context);
        _repositories[entityType] = newRepository;
        return newRepository;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}
