using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder2;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace Pingis.DataModel.Resolver
{
    public class UnityResolver : IDependencyResolver 
    {

        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
           Dispose(true);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            container.Dispose();
        }
    }
}
