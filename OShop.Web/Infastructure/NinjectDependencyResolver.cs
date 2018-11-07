using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using OShop.Data.Abstract;
using OShop.Data;

namespace OShop.Web.Infastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) { kernel = kernelParam; AddBindings(); }

        public object GetService(Type serviceType) { return kernel.TryGet(serviceType); }

        public IEnumerable<object> GetServices(Type serviceType) { return kernel.GetAll(serviceType); }

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<ProductsRepository>();
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
        }
    }
}