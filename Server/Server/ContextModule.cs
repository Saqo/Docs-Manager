using Core;
using Ninject.Activation;
using Ninject.Modules;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Repositories;
using Core.Repositories;
using EFInfrastructure;

namespace Server
{
    class ContextModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataContext>().To<ConcreteContext>();
            Bind<IUserRepository>().To<UsersRepository>();
            Bind<IDocumentRepository>().To<DocumentsRepository>();
        }
    }
}
