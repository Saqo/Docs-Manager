using System;
using Nancy.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Modules
{
    class DocumentsModule : Nancy.NancyModule
    {
        public DocumentsModule()
        {
            this.RequiresAuthentication();
            Get["/"] = param =>
            {
                return View["Views/Documents/Index.html"];
            };
        }
    }
}
