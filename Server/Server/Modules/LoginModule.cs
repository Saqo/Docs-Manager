using Nancy;
using Nancy.Security;
using Nancy.Authentication.Forms;
using Server.Contexts;
using Server.Models;
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
                var userName = (string)this.Request.Form.username;
                var password = (string)this.Request.Form.password;
                String sql = "select * from dbo.Users where UserName ='" + userName + "'";
                var user = PetaPocoDBManager.GetDatabase().FirstOrDefault<User>(sql);
                if (user != null && user.Password.Equals(password))
                {
                    var token = user.Id;
                    return this.LoginAndRedirect(token);
                }
                else
                    throw new ArgumentException("Invalid username or password");
            };

            Get["/Logout"] = param =>
            {
                return this.LogoutAndRedirect("~/");
            };
        }
    }
}
