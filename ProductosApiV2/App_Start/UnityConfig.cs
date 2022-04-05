using ServiciosAplicacion.Definiciones;
using ServiciosAplicacion.Implementaciones;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace ProductosApiV2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProductoServicioAplicacion, ProductoServicioAplicacion>(new HierarchicalLifetimeManager());
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}