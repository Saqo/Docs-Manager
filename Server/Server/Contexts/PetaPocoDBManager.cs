using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Contexts
{
    class PetaPocoDBManager
    {
        public static PetaPoco.Database GetDatabase()
        {
            String connectionString = @"Server=.\SQLExpress;Integrated security=SSPI;Initial Catalog=" + Program.DBFileName;
            PetaPoco.Database db = new PetaPoco.Database(connectionString, "System.Data.SqlClient");
            return db;
        }
    }
}
