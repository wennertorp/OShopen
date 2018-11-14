using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using Ninject;
using Ninject.Web.Common;
using OShop.Data.Abstract;
using OShop.Data;
using OShop.Order.Abstract;
using OShop.Order.Processors;
using OShop.Order.PSP;

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
            kernel.Bind<ICartRepository>().To<CartRepository>();
            kernel.Bind<IOrderProcessor>().To<OrderProcessor>();
            kernel.Bind<IPSP>().To<DummyPSP>();
            //kernel.Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();
            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();

        }
    }
}