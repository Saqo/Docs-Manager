using System;
using System.Linq;

namespace Core.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable
    {
        IQueryable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
