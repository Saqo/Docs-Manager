using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Server.Models
{
    public class NancyUser : User, IUserIdentity
    {
        public NancyUser(User user)
        {
            this.Claims = user.Claims;
            this.Id = user.Id;
            this.IsAdmin = user.IsAdmin;
            this.Password = user.Password;
            this.UserName = user.UserName;
        }
    }
}
