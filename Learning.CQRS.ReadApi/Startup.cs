using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Learning.CQRS.ReadApi;
using Learning.CQRS.ReadApi.Activator;
using Learning.CQRS.ReadApi.Activator.Helper;
using Learning.CQRS.ReadApi.Activator.Resolver;

[assembly: OwinStartup(typeof(Startup))]
namespace Learning.CQRS.ReadApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            Bootstrapper.Run();

            var config = new HttpConfiguration
            {
                DependencyResolver = new ApiDependencyResolver(Bootstrapper.Container)
            };

            ConfigureOAuth(app);

            var cors = new EnableCorsAttribute(HostSettings.Default.Origins, "*", "*");
            config.EnableCors(cors);


            var routeHandler = HttpClientFactory.CreatePipeline(new HttpControllerDispatcher(config), new DelegatingHandler[]
            {

            });

            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "Default",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { name = RouteParameter.Optional, id = RouteParameter.Optional },
            //    constraints: null,
            //    handler: routeHandler
            //);

            config.Routes.MapHttpRoute(
                    name: "Default",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional },
                    constraints: null,
                    handler: routeHandler);




            config.UseJsonFormatters();
            config.EnsureInitialized();
            app.MapSignalR();
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

        }



        private void ConfigureOAuth(IAppBuilder app)
        {
            //Token Consumption
            var authenticationOptions = new OAuthBearerAuthenticationOptions
            {
                AccessTokenFormat = new TicketDataFormat(new MachineKeyDataProtector(
                    typeof(OAuthBearerAuthenticationMiddleware).Namespace, "Access_Token", "v1")),

                AuthenticationMode = AuthenticationMode.Active
            };

            app.UseOAuthBearerAuthentication(authenticationOptions);
        }
    }
}
