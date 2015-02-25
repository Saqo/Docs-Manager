using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Context
{
    public interface IContext
    {
        void Add(Object entity);
        void Remove(Object entity);
        void Dispose();
        void SaveChanges();
    }

    public interface IContext<T>: IContext
    {
        IQueryable<T> Set<T>();
    }
}
