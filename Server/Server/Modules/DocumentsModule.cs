using System;
using Nancy.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace Server.Modules
{
    class DocumentsModule : NancyModule
    {
        public DocumentsModule()
            : base("/Documents")
        {
            this.RequiresAuthentication();

            Get["/GetAll"] = param =>
            {
                return View["Views/Documents/Index.html"];
            };

            Get["/Add"] = param =>
            {
                return null;
            };

            Post["/Add"] = param =>
            {
                return null;
            };

            Delete["/Delete/{id}"] = param =>
            {
                return null;
            };
        }
    }
}
