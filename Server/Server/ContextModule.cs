using Core;
using Ninject.Activation;
using Ninject.Modules;
using Server.Contexts;
using Server.Models;
using Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.ORM;

namespace Server
{
    class ContextModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataContext>().To<ConcreteContext>();
            Bind<IUserRepository>().To<UsersRepository>();
        }
    }
}
