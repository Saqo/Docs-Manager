using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DB
{
    public class DBManager
    {
        public static void CreateDocumentsTable(string folder, string filename)
        {
            String FullPath = Path.Combine(folder, filename, ".db");

            String dbConnection = String.Format("Data Source={0}", FullPath);
            String sql = @"
                        create table [Documents] (
                        [Id] INTEGER PRIMARY KEY ASC,
                        [Title] varchar(256)";

            ExecuteNonQuery(dbConnection, sql);

        }

        public static int ExecuteNonQuery(string dbConnection, string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            try
            {
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn);
                mycommand.CommandText = sql;
                int rowsUpdated = mycommand.ExecuteNonQuery();
                return rowsUpdated;
            }
            catch (Exception fail)
            {
                Console.WriteLine(fail.Message);
                return 0;
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
