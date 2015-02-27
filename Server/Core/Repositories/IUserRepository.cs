using System;
using Core.Models;

namespace Core.Repositories
{
    public interface IUserRepository : IRepositoryBase<RegistrationUser>
    {
        void AddUser(string userName, string password);
        RegistrationUser GetUserByName(string userName);
        User GetUserFromIdentifier(Guid id);

    }
}
