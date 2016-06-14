using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConfigurationSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("app2.json", optional: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args);


            if (Environment.GetEnvironmentVariable("Environment").Equals("DEVELOP"))
            {
                config.AddUserSecrets();
            }
            Config = config.Build();

            ReadConfig();
            ShowSecrets();
        }

        private static void ShowSecrets()
        {
            string secret = Config["arealsecret"];
            Console.WriteLine(secret);
        }

        private static void ReadConfig()
        {
            string setting1 = Config["Setting1"];
            Console.WriteLine(setting1);
            string connectionString1 = Config["ConnectionStrings:BooksDB"];
            Console.WriteLine(connectionString1);
            string connectionString2 = Config.GetSection("ConnectionStrings")["BookDB"];
            Console.WriteLine(connectionString2);
            string connectionString3 = Config.GetConnectionString("BooksDB");
            Console.WriteLine(connectionString3);
            //var sections = Config.GetChildren();
            //foreach (var section in sections)
            //{
            //    Console.WriteLine($"key: {section.Key}, value: {section.Value}");
            //}
        }

        public static IConfigurationRoot Config { get; set; }
    }
}
