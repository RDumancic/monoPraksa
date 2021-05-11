using Autofac;
using day6_8.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6_8.Repository
{
    public class RepositoryModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
        }
    }
}
