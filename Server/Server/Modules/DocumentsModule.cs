using System;
using Nancy.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;
using Server.Models;
using Server.Contexts;
using Server;
using Nancy.Responses;

namespace Server.Modules
{
    public class DocumentsModule : NancyModule
    {
        public DocumentsModule()
        {
            this.RequiresAuthentication();
            this.RequiresAnyClaim(new[] { "Users", "Admins" });

            Get["/"] = param =>
            {
                return View["Views/Documents/Index.html"];
            };

            Get["/UserDocs/{id}"] = param =>
            {
                
                return GetUserDocs((Guid)param.id);
            };

            Get["/Add"] = param =>
            {
                return View["Views/Documents/Form.html"];
            };

            Post["/Add"] = param =>
            {
                string title = (string)param.Request.Form.Title;
                string description = (string)param.Request.Form.Description;
                Guid userId = (Guid)param.Request.Form.UserId;
                DocumentsContext ctx = new DocumentsContext();
                ctx.Add(new Document() { Title = title, Description = description, UserId = userId });
                return View["Views/Documents/Index.html"];
            };
        }

        Response GetUserDocs(Guid userId)
        {
            try
            {
                DocumentsContext ctx = new DocumentsContext();
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
