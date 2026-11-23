using Ecommers.Domain.Entites;
using Ecommers.Domain.commov;

namespace Ecommers.Domain.commov.contractic
{
   public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : BaseEntity;
    }
}
