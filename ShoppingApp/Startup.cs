using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;

namespace ShoppingApp
{
    public class ErrorHandlingPipelineModule : HubPipelineModule
    {
        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
        {
            Debug.WriteLine("=> Exception " + exceptionContext.Error.Message);
            if (exceptionContext.Error.InnerException != null)
            {
                Debug.WriteLine("=> Inner Exception " + exceptionContext.Error.InnerException.Message);
            }
            base.OnIncomingError(exceptionContext, invokerContext);

        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            try
            {
            GlobalHost.HubPipeline.AddModule(new ErrorHandlingPipelineModule());
            Debug.WriteLine("hello");
            app.UseCors(CorsOptions.AllowAll);

            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfig = new HubConfiguration { EnableDetailedErrors = true };
                map.RunSignalR(hubConfig);
            });

            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);
                app.UseWebApi(config);
            } catch (Exception e)
            {
                Debug.Write(e);
                throw;
            }
        }
    }
}