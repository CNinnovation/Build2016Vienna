using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjectionSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Container = RegisterServices();
            Run();
        }

        private static void Run()
        {
            var controller = Container.GetService<HelloController>();
            Console.WriteLine(controller.Index("Stephanie"));
        }

        public static IServiceProvider Container { get; private set; }

        private static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection()
                .AddSingleton<IHelloService, HelloService>()
                .AddTransient<HelloController>();

            return services.BuildServiceProvider();
        }
    }
}
