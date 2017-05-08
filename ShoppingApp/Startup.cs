using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShoppingApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            appBuilder.UseWebApi(config);

            //appBuilder.MapSignalR();
        }
    }
}