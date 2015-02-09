using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DB
{
    public class DBManager
    {
        public static void DropDatabase(string DBFileName)
        {
            string sql = "DROP DATABASE [" + DBFileName + "]";
            ExecuteNonQuery(sql, "master");
        }

        public static void InsertUser(string Name, string Password, bool IsAdmin, string DBFileName)
        {
            String sql = @"insert into Users ([UserName], [Password], [IsAdmin]) 
                           values ('" + Name + "', '" + Password + "', '" + IsAdmin + "');";
            ExecuteNonQuery(sql, DBFileName);
        }

        public static void DropUsersTable(string DBFileName)
        {
            String sql = @"drop table [Users]";
            ExecuteNonQuery(sql, DBFileName);
        }

        public static void DropDocumentsTable(string DBFileName)
        {
            String sql = @"drop table [Documents]";
            ExecuteNonQuery(sql, DBFileName);
        }

        public static string GetDBFileFullName(string DBFileName)
        {
            //string folder = "";
            string FullfileName;
            //String[] arr = Environment.CurrentDirectory.Split('\\');
            //for (int i = 0; i < arr.Length - 2; i++)
            //{
            //    string part1 = folder, part2 = arr[i];
            //    if (i == 1)
            //        part1 = part1 + "\\";
            //    folder = Path.Combine(part1, part2);
            //}
            FullfileName = Path.Combine("C:\\Program Files\\Microsoft SQL Server\\MSSQL10.SQLEXPRESS\\MSSQL\\DATA", DBFileName);
            return FullfileName;
        }

        public static void CreateDatabase(string fileName, string fullFileName)
        {
            string str = "CREATE DATABASE " + fileName + " ON PRIMARY " +
              "(NAME = " + fileName + ", " +
              "FILENAME = '" + fullFileName + ".mdf'," +
              "SIZE = 3MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
              "LOG ON (NAME = " + fileName + "_Log, " +
              "FILENAME = '" + fullFileName + ".ldf', " +
              "SIZE = 1MB, " +
              "MAXSIZE = 5MB, " +
              "FILEGROWTH = 10%)";
            ExecuteNonQuery(str, "master");
        }

        public static void CreateDocumentsTable(string DBFileName)
        {
            String sql = @"
                        create table [Documents] (
                        [Id] int identity(1,1),
                        [Title] nvarchar(128) ,
                        [Description] nvarchar(1024),
                        [UserId] uniqueidentifier,
                        CONSTRAINT PK_Documents PRIMARY KEY (Id),
                        CONSTRAINT FK_Documents_Users FOREIGN KEY(UserId)
                        REFERENCES Users(Id))";
            ExecuteNonQuery(sql, DBFileName);
        }

        public static void CreateUsersTable(string DBFileName)
        {
            String sql = @"
                        create table [Users] (
                        [Id] uniqueidentifier default newid(),                        
                        [UserName] nvarchar(1024) ,
                        [Password] nvarchar(1024) ,
                        [IsAdmin] bit, 
                        CONSTRAINT PK_Users PRIMARY KEY (Id))";
            ExecuteNonQuery(sql, DBFileName);
        }


        public static void ExecuteNonQuery(string sql, string InitialCatalog)
        {
            SqlConnection myConn = new SqlConnection(@"Server=.\SQLExpress;Integrated security=SSPI;Initial Catalog=" + InitialCatalog);
            SqlCommand myCommand = new SqlCommand(sql, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}
