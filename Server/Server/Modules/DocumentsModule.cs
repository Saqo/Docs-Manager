using System;
using Nancy.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Nancy;
using Nancy.ModelBinding;
using Server.Models;
using Server;
using Nancy.Responses;
using Ninject;

namespace Server.Modules
{
    public class DocumentsModule : NancyModule
    {
        public DocumentsModule()
        {
            this.RequiresAuthentication();
            this.RequiresAnyClaim(new[] { "Users", "Admins" });

            Get["/"] = param => { return View["Views/Documents/Index.html"]; };

            Get["/UserDocs/{id}"] = param => { return GetUserDocs((Guid)param.id); };

            Get["/Add"] = param => { return View["Views/Documents/Form.html"]; };

            Post["/Add"] = param =>
            {
                string title = (string)param.Request.Form.Title;
                string description = (string)param.Request.Form.Description;
                Guid userId = (Guid)param.Request.Form.UserId;
                using (IDocumentRepository ctx = Program.NinjectKernel.Get<IDocumentRepository>())
                {
                    ctx.Add(new Document() { Title = title, Description = description });
                    return View["Views/Documents/Index.html"];
                }
            };
        }

        Response GetUserDocs(Guid userId)
        {


            using (IDocumentRepository ctx = Program.NinjectKernel.Get<IDocumentRepository>())
            {
                try
                {
                    IEnumerable<Document> docs = ctx.GetAllByUserId(userId);
                    Nancy.Response resp = new Nancy.Responses.JsonResponse<IEnumerable<Document>>(docs, new DefaultJsonSerializer());
                    return resp;
                }
                catch
                {
                    throw new Exception("Error on GetById");
                }

            }


        }
    }
}
