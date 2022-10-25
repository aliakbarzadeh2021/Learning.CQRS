using System;
using Learning.CQRS.WriteApi.App_Start;
using Topshelf;

namespace Learning.CQRS.WriteApi
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

                    x.SetDescription("Samim LearningCenter Write API");
                    x.SetDisplayName("Samim LearningCenter Write API");
                    x.SetServiceName("SamimLearningCenterWriteAPI");

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
