using Nancy;
using Nancy.Security;
using Nancy.Authentication.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Contexts;

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
                DocumentsContext ctx = new DocumentsContext();
                ctx.Delete(p);
                return View["~/"];
            };
        }
    }
}
