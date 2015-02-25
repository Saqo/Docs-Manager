using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.IO;
using Nancy.Bootstrapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using Server.Models;
using Server.Repositories;
using Ninject;
using DependencyResolver;

namespace Server
{
    class Program
    {
        public static readonly IKernel NinjectKernel = new StandardKernel(new ContextModule());
        public const string DBFileName = "DocsManager";
        static void Main(string[] args)
        {

            using (IUserRepository ctx = NinjectKernel.Get<IUserRepository>())
            {
                ctx.Add(new RegistrationUser()
                {
                    Id = Guid.NewGuid(),
                    IsAdmin = true,
                    Password = "Password2",
                    UserName = "Nikolay"
                });
                ctx.SaveChanges();
            }



            NancyHost Host = new NancyHost(new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true },
                AllowChunkedEncoding = false
            }, new Uri("http://localhost:9900"));
            Host.Start();
            Console.WriteLine("Server started");
            Console.ReadLine();
            Host.Stop();
            Console.WriteLine("Server stoped");
        }
    }
}
