using System.Web.Http;
using Microsoft.Practices.Unity;
using OrderManagement.Assembler;
using OrderManagement.Domain;
using OrderManagement.Repository;
using OrderManagementBackend.Controllers;
using DTO = OrderManagement.DTO;

namespace OrderManagementBackend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Setup the container
            var container = new UnityContainer();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IReadOnlyRepository<Product>, ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAssembler<DTO.Order, Order>, OrderAssembler>();
            container.RegisterType<IAssembler<DTO.Product, Product>, ProductAssembler>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "OrderManagement",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            

        }
    }
}
