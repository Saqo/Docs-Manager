using Core;
using Server.Models;
using Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Contexts
{
    public class UsersRepository : RepositoryBase<RegistrationUser, IDataContext>, IUserRepository
    {
        public UsersRepository(IDataContext context)
            : base(context)
        {

        }
        public User GetUserFromIdentifier(Guid id)
        {
            RegistrationUser user = base.GetAll().First(x => x.Id == id);
            if (user == null)
                return null;
            IEnumerable<string> claims;
            if (user.IsAdmin)
                claims = new[] { "Admins" };
            else
                claims = new[] { "Users" };
            return new User()
            {
                Claims = claims,
                Id = user.Id,
                IsAdmin = user.IsAdmin,
                Password = user.Password,
                UserName = user.UserName
            };
        }

        public void AddUser(string userName, string password)
        {
            base.Context.Add(new RegistrationUser()
            {
                Id = Guid.NewGuid(),
                IsAdmin = false,
                UserName = userName,
                Password = password
            });
            base.SaveChanges();
        }

        public RegistrationUser GetUserByName(string userName)
        {
            return base.GetAll().First(e => e.UserName.Equals(userName));
        }
    }
}
