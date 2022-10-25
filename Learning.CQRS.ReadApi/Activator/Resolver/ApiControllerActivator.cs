using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel;
using Castle.Windsor;

namespace Learning.CQRS.ReadApi.Activator.Resolver
{
    public class ApiControllerActivator : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;

        public ApiControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            try
            {
                var controller = _container.Kernel.HasComponent(controllerType) ? (IHttpController)_container.Resolve(controllerType) : null;
                request.RegisterForDispose(new Release(() => _container.Release(controller)));
                return controller;
            }
            catch (ComponentNotFoundException)
            {
                return null;
            }
        }

        private class Release : IDisposable
        {
            private readonly Action _release;

            public Release(Action release)
            {
                _release = release;
            }

            public void Dispose()
            {
                _release();
            }
        }
    }
}
