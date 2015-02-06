using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Get["/Login"] = param =>
            {
                return View["Views/Login/Form.html"];
            };

            Post["/Login"] = param =>
            {
                return null;
            };

            Get["/Logout"] = param =>
            {
                return null;
            };
        }
    }
}
