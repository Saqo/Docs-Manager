using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var Host = new NancyHost(new Uri("http://localhost:8800"));
            Host.Start();
            Console.WriteLine("Server started");
            Console.ReadLine();
            Host.Stop();
            Console.WriteLine("Server stoped");
        }
    }
}
