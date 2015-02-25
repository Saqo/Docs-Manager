using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable
    {
        IQueryable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
