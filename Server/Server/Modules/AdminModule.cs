using Nancy;
using Nancy.Security;
using Nancy.Authentication.Forms;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Server.Models;

namespace Server.Modules
{
    class AdminModule : NancyModule
    {
        public AdminModule()
        {
            this.RequiresAuthentication();
            this.RequiresClaims(new[] { "Admins" });

            Delete["/delete"] = p =>
            {
                using (IDocumentRepository ctx = Program.NinjectKernel.Get<IDocumentRepository>())
                {
                    ctx.Delete(p);
                    return View["~/"];
                }
            };
        }
    }
}
