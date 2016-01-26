using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Ninject.Web.Common;

namespace MongoDataSource.API
{
    public class WebApiApplication : NinjectHttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected override Ninject.IKernel CreateKernel()
        {
            throw new NotImplementedException();
        }
    }
}
