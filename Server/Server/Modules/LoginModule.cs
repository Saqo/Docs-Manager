using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class LoginModule : Nancy.NancyModule
    {
        public LoginModule()
            : base("/Login")
        {
            Get["/"] = param =>
            {
                return View["Views/Login/Form.html"];
            };
        }
    }
}
