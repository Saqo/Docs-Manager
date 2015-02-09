using Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Contexts
{
    public class DocumentsContext
    {
        private PetaPoco.Database DB = PetaPocoDBManager.GetDatabase();
        public IEnumerable<Document> GetAllByUserId(Guid id)
        {
            String sql = "select * from Documents where UserId ='" + id + "'";
            return DB.Query<Document>(sql);
        }

        public void Add(Document doc)
        {
            DB.Insert(doc);
        }

        public void Delete(Int64 id)
        {
            DB.Delete<Document>(id);
        }
    }
}
