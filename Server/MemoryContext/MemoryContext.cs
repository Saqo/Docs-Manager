using Core;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryContext
{
    public class MemoryContext: IDataContext
    {
        public List<Document> Documents { get; set; }
        public List<RegistrationUser> Users { get; set; }

        public void Add(Object entity)
        {
            if (entity.GetType() == typeof(Document))
            {
                Documents.Add(entity as Document);
            }
        }

        public new void SaveChanges()
        {
        }

        public void Remove(object entity)
        {
            if (entity.GetType() == typeof(Document))
            {
                Documents.Remove(entity as Document);
            }
        }

        public new IQueryable<T> Set<T>() where T : class
        {
            if (typeof(T) == typeof(Document))
            {
                return Documents.Cast<T>().AsQueryable<T>();
            }
            return null;
        }

        public void Dispose()
        {
        }
    }
    }
