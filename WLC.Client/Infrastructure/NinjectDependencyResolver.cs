using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Ninject;
using WLC.Admin.Infrastructure.Abstract;
using WLC.Admin.Infrastructure.Concrete;
using WLC.Domain.Interface;
using WLC.Domain.Repo;

namespace WLC.Admin.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            /*
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product(){Name = "Football", Price = 25},
                new Product(){Name = "Surf board", Price = 179},
                new Product(){Name = "Running shoes", Price = 95}
            });

            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>();
            */
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            kernel.Bind<IKullaniciRepo>().To<KullaniciRepo>();
            kernel.Bind<IWLCTanimRepo>().To<WLCTanimRepo>();
            kernel.Bind<IKullaniciYapilanAp>().To<KullaniciYapilanApRepo>();
        }
    }
}