using Nancy.Hosting.Self;
using Server.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public const string DBFileName = "DocsManager";
        static void Main(string[] args)
        {

            string DBFullFileName = DBManager.GetDBFileFullName(DBFileName);
            if (!File.Exists(DBFullFileName + ".mdf"))
            {
                //DBManager.DropDocumentsTable(DBFileName);
                //DBManager.DropUsersTable(DBFileName);
                //DBManager.DropDatabase(DBFileName);
                DBManager.CreateDatabase(DBFileName, DBFullFileName);
                DBManager.CreateUsersTable(DBFileName);
                DBManager.CreateDocumentsTable(DBFileName);
                DBManager.InsertUser("Nikolay", "Password2", true, DBFileName);
                //DBManager.InsertUser("Alex", "Password1", "False", DBFileName);
                //DBManager.InsertUser("Paul", "Password3", "False", DBFileName);
                //DBManager.InsertUser("Petr", "Password4", "False", DBFileName);
                //DBManager.InsertUser("George", "IAMADMIN", "True", DBFileName);
            }

            NancyHost Host = new NancyHost(new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true },
                AllowChunkedEncoding = false
            }, new Uri("http://localhost:8080"));
            Host.Start();
            Console.WriteLine("Server started");
            Console.ReadLine();
            Host.Stop();
            Console.WriteLine("Server stoped");
        }
    }
}
