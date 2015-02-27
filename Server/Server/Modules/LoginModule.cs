using System;
using Core.Models;
using Core.Repositories;
using Nancy;
using Nancy.Authentication.Forms;
using Ninject;

namespace Server.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Get["/Login"] = param => { return View["Views/Login/Form.html"]; };

            Post["/Login"] = param =>
            {

                var userName = (string)this.Request.Form.username;
                var password = (string)this.Request.Form.password;
                using (IUserRepository ctx = Program.NinjectKernel.Get<IUserRepository>())
                {

                    RegistrationUser user = ctx.GetUserByName(userName);

                    if (user != null && user.Password.Equals(password))
                    {
                        var token = user.Id;
                        return this.LoginAndRedirect(token);
                    }
                    else
                        throw new ArgumentException("Invalid username or password");
                }
            };

            Get["/Logout"] = param => { return this.LogoutAndRedirect("~/"); };
        }
    }
}
