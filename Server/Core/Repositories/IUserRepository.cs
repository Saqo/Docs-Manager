using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface IUserRepository : IRepositoryBase<RegistrationUser>
    {
        void AddUser(string userName, string password);
        RegistrationUser GetUserByName(string userName);
        User GetUserFromIdentifier(Guid id);

    }
}
