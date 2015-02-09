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
    class DocumentsContext
    {
        private PetaPoco.Database DB = GetDatabase();
        public Document GetAllByUserId(Guid id)
        {

            String sql = "select * from Documents where Id =" + id.ToString();
            return GetDatabase().FirstOrDefault<Document>(sql);
        }
        private static PetaPoco.Database GetDatabase()
        {
            // A sqlite database is just a file.
            String fileName = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "documents.db");
            String connectionString = "Data Source=" + fileName;
            PetaPoco.Database db = new PetaPoco.Database(connectionString);
            return db;
           
        }
    }
}
