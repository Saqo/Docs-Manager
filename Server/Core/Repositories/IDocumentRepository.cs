using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface IDocumentRepository : IRepositoryBase<Document>
    {
        IEnumerable<Document> GetAllByUserId(Guid Id);
    }
}
