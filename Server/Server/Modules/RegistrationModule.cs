using Nancy;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using System.Threading.Tasks;
using Core.Repositories;

namespace Server.Modules
{
    class RegistrationModule : NancyModule
    {
        public RegistrationModule()
        {
            Get["/Reg"] = parameters => { return View["Views/Registration/Form.html"]; };

            Post["/Reg"] = parameters =>
            {
                using (IUserRepository ctx = Program.NinjectKernel.Get<IUserRepository>())
                {
                    ctx.AddUser((string)this.Request.Form.UserName, (string)this.Request.Form.Password);
                    return View["Views/Login/Form.html"];
                }
            };
        }
    }
}
