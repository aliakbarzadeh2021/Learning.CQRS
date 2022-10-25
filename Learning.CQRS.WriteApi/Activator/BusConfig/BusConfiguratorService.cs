using System;
using Castle.MicroKernel.Registration;
using MassTransit;

namespace Learning.CQRS.WriteApi.Activator.BusConfig
{
    public class BusConfiguratorService
    {
        public static void Configure()
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://" + HostSettings.Default.RabbitMQ_ServerName + "/"), h =>
                {
                    h.Username(HostSettings.Default.RabbitMQ_UserName);
                    h.Password(HostSettings.Default.RabbitMQ_Password);
                });

                //cfg.UseLog4Net();

            });

            busControl.Start();

            Bootstrapper.Container.Register(Component.For<IBus>().Instance(busControl).LifestyleSingleton());
        }
    }
}
