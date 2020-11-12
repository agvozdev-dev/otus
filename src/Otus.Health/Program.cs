using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Otus.Health
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"HOSTNAME: {Dns.GetHostName()}");
        
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS"));
                });
    }
}