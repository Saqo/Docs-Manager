using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Contexts
{
    public class UsersContext : IUserMapper
    {
        private PetaPoco.Database DB = PetaPocoDBManager.GetDatabase();
        public IUserIdentity GetUserFromIdentifier(Guid id, NancyContext ctx)
        {
            String sql = "select * from dbo.Users where Id ='" + id.ToString() + "'";
            var user = DB.FirstOrDefault<User>(sql);
            if (user == null)
                return null;
            IEnumerable<string> claims;
            if (user.IsAdmin)
                claims = new[] { "Admins" };
            else
                claims = new[] { "Users" };
            return new User
            {
                Id = user.Id,
                UserName = user.UserName,
                Claims = claims,
                Password = user.Password,
            };
        }

        public void AddUser(string userName, string password)
        {
            DB.Insert(new User()
            {
                UserName = userName,
                Password = password,
                IsAdmin = false
            });
        }
    }
}
