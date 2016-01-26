using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace MongoDataSource.DAL
{
    public class DalNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<MongoRepository>();
        }
    }
}
