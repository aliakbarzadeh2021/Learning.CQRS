using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Lifestyle;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.OAuth;
using Owin;
using OWIN.Windsor.DependencyResolverScopeMiddleware;
using Learning.CQRS.WriteApi;
using Learning.CQRS.WriteApi.Activator;
using Learning.CQRS.WriteApi.Activator.Helper;
using Learning.CQRS.WriteApi.Activator.Resolver;

[assembly: OwinStartup(typeof(Startup))]
namespace Learning.CQRS.WriteApi
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {

            Bootstrapper.Run();
            Bootstrapper.Container.AddFacility<AttributeFacility>();


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

            app.UseWindsorDependencyResolverScope(config, Bootstrapper.Container);

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



    [Serializable]
    public class PerWebRequestLifestyleManager : ScopedLifestyleManager
    {
        private TransientLifestyleManager fallback;

        public PerWebRequestLifestyleManager()
        : base(new WebRequestScopeAccessor())
        {
            fallback = new TransientLifestyleManager();
        }

        public override object Resolve(CreationContext context, IReleasePolicy releasePolicy)
        {
            HttpContext current = HttpContext.Current;

            if (null == current || current.ApplicationInstance == null)
            {
                // Fall back to transient behavior if not in web context.
                return fallback.Resolve(context, releasePolicy);
            }
            else
            {
                return base.Resolve(context, releasePolicy);
            }
        }

        public override void Dispose()
        {
            fallback.Dispose();

            base.Dispose();
        }

        public override void Init(IComponentActivator componentActivator, IKernel kernel, ComponentModel model)
        {
            base.Init(componentActivator, kernel, model);

            fallback.Init(componentActivator, kernel, model);
        }
    }


    internal class AttributeFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.ComponentModelCreated += kernel_ComponentModelCreated;
        }

        void kernel_ComponentModelCreated(ComponentModel model)
        {
            var attributes = model.Implementation.GetCustomAttributes(typeof(Castle.Core.LifestyleAttribute), false);
            if (attributes.Length > 0)
            {
                var attr = attributes[0] as LifestyleAttribute;
                if (null != attr)
                {
                    switch (attr.Lifestyle)
                    {
                        case LifestyleType.PerWebRequest:
                            model.CustomLifestyle = typeof(PerWebRequestLifestyleManager);
                            model.LifestyleType = LifestyleType.Custom;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

}
