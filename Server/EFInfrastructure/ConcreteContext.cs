using System;
using System.Data.Entity;
using System.Linq;
using Core;
using Core.Models;

namespace EFInfrastructure
{
    public class ConcreteContext : DbContext, IDataContext
    {
        public ConcreteContext()
            : base("name=BaseContext")
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
