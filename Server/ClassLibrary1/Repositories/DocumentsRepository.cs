using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Models;
using Core.Repositories;

namespace ClassLibrary1.Repositories
{
    public class DocumentsRepository : RepositoryBase<Document, IDataContext>, IDocumentRepository
    {
        public DocumentsRepository(IDataContext context)
            : base(context)
        {

        }
        public IEnumerable<Document> GetAllByUserId(Guid id)
        {
            return base.GetAll().Where(e => e.RegistrationUserId == id);
        }

        public override void Add(Document doc)
        {
            base.Add(doc);
            base.SaveChanges();
        }

        public override void Delete(Document doc)
        {
            base.Delete(doc);
            base.SaveChanges();
        }
    }
}
