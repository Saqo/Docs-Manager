using Core;
using Server.Models;
using Server.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ORM
{
    public class ConcreteContext : DbContext, IDataContext
    {
        public ConcreteContext()
            : base("DocsManager")
        {

        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<RegistrationUser> Users { get; set; }

        public void Add(Object entity)
        {
            base.Set(entity.GetType()).Add(entity);
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public void Remove(object entity)
        {
            base.Set(entity.GetType()).Remove(entity);
        }

        public new IQueryable<T> Set<T>() where T : class
        {
            return base.Set<T>() as IQueryable<T>;
        }
    }
}
