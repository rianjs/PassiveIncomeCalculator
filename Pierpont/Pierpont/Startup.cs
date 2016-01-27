using System;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Owin;

namespace Pierpont
{
    public class PierpontControllerActivator : IHttpControllerActivator
    {
        private readonly IPierpontService _pierpont;
        private readonly CancellationTokenSource _cts;
        public PierpontControllerActivator(IPierpontService pierpontInstance, CancellationTokenSource cts)
        {
            _pierpont = pierpontInstance;
            _cts = cts;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return new PierpontController(_pierpont, _cts);
        }
    }

    public class Startup
    {
        public static void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            var cts = new CancellationTokenSource();
            var seshat = new PierpontService(cts);

            config.Services.Replace(typeof(IHttpControllerActivator), new PierpontControllerActivator(seshat, cts));
            appBuilder.UseWebApi(config);
        }
    }

}
