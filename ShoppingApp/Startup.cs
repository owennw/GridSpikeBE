using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using ShoppingApp.Hubs;
using System;
using System.Reflection;
using System.Web.Http;

namespace ShoppingApp
{
    public class Startup
    {
        private static readonly Lazy<JsonSerializer> JsonSerializerFactory = new Lazy<JsonSerializer>(GetJsonSerializer);

        public void Configuration(IAppBuilder app)
        {
            log4net.Config.XmlConfigurator.Configure();
            app.UseCors(CorsOptions.AllowAll);

            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);

            app.MapSignalR(new HubConfiguration { EnableDetailedErrors = true });

            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => JsonSerializerFactory.Value);
        }

        private static JsonSerializer GetJsonSerializer()
        {
            return new JsonSerializer
            {
                ContractResolver = new FilteredCamelCasePropertyNamesContractResolver
                {
                    // 1) Register all types in specified assemblies:
                    AssembliesToInclude =
                 {
                     typeof (Startup).Assembly
                 },
                    // 2) Register individual types:
                    //TypesToInclude =
                    //                {
                    //                    typeof(Hubs.Message),
                    //                }
                }
            };
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}