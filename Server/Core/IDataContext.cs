using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IDataContext
    {
        void Add(Object entity);
        void Remove(Object entity);
        void Dispose();
        void SaveChanges();
        IQueryable<T> Set<T>() where T : class;
    }
}
