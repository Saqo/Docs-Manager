using System.Linq;

namespace Core.Repositories
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class
        where TContext : IDataContext
    {
        public RepositoryBase(TContext ctx)
        {
            _db = ctx;
        }
        private TContext _db;
        protected TContext Context
        {
            get { return _db; }
            set { _db = value; }
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _db.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _db.Remove(entity);
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }


        public virtual void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
