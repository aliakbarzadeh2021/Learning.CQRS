using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.CQRS.ReadApi.App_Start;
using Topshelf;

namespace Learning.CQRS.ReadApi
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var host = HostFactory.New(x =>
                {
                    x.Service<ApiStart>(s =>
                    {
                        s.ConstructUsing(name => new ApiStart());
                        s.WhenStarted(tc => tc.Start());
                        s.WhenStopped(tc => tc.Stop());
                    });

                    x.UseLog4Net();
                    x.EnableShutdown();
#if (DEBUG)
                    x.RunAsLocalService();
#endif
#if (!DEBUG)
                x.RunAsNetworkService();
#endif
                    x.StartAutomaticallyDelayed();

                    x.SetDescription("Samim LearningCenter Read API");
                    x.SetDisplayName("Samim LearningCenter Read API");
                    x.SetServiceName("SamimLearningCenterReadApi");

                });

                host.Run();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                // ignored
            }
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject);
        }
    }
}
