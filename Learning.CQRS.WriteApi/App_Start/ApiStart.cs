using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using SAF.Kernel.Microservice;
using SAF.Kernel.Microservice.Settings;

// ReSharper disable once CheckNamespace
namespace Learning.CQRS.WriteApi.App_Start
{
    public class ApiStart
    {
        readonly string _baseAddress = HostSettings.Default.HostApiAddress;
        private IDisposable _server = null;


        public void Start()
        {
            try
            {
                ServiceIntroducer1.StandUp(Assembly.GetExecutingAssembly());
                _server = WebApp.Start<Startup>(url: _baseAddress);
                Console.WriteLine("Listening on: " + _baseAddress);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    msg += "\n" + ex.Message;
                }

                Console.WriteLine(msg);
                Console.ReadLine();
            }

        }

        public void Stop()
        {
            if (_server != null)
            {
                _server.Dispose();
                ServiceIntroducer.ShutDown();
            }
        }
    }

    public static class ServiceIntroducer1
    {
        public static void StandUp(Assembly executingAssembly)
        {
            var services = new Dictionary<string, string[]>();
            Scan(executingAssembly, services);
            Introduce(services);
        }

        public static void ShutDown()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MicroserviceSettingFactory.GetSetting().GatewayAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var queryString = string.Format("name={0}&ip={1}",
                    MicroserviceSettingFactory.GetSetting().MicroserviceName,
                    MicroserviceSettingFactory.GetSetting().IPAddress);
                var response = client.PostAsJsonAsync("UnRegister", queryString).Result;
            }
        }

        private static void Scan(Assembly assembly, IDictionary<string, string[]> services)
        {
            assembly.GetTypes().Where(x => x.IsClass && x.IsPublic && x.Name.EndsWith("Controller")).ToList().ForEach(
                controller =>
                {
                    services.Add(controller.Name.Replace("Controller", ""),
                        controller.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                            .Select(x => x.Name)
                            .Distinct()
                            .ToArray());
                });
        }

        private static void Introduce(IDictionary<string, string[]> services)
        {
            Console.WriteLine("Introduce Starting ...");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MicroserviceSettingFactory.GetSetting().GatewayAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonServices = JsonConvert.SerializeObject(services, Formatting.Indented);
                //var result = client.GetAsync("Register").Result;
                var response =
                    client.PostAsJsonAsync(
                        string.Format("Register?name={0}&ip={1}",
                            MicroserviceSettingFactory.GetSetting().MicroserviceName,
                            MicroserviceSettingFactory.GetSetting().IPAddress), jsonServices).Result;

                Console.WriteLine("Response :" + response);
            }
        }
    }
}
