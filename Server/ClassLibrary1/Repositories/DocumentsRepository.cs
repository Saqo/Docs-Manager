using Core;
using Server.Models;
using Server.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Contexts
{
    public class DocumentsRepository : RepositoryBase<Document, IDataContext>, IDocumentRepository
    {
        public DocumentsRepository(IDataContext context):base(context)
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
