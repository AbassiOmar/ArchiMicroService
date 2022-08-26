using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingLibrary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace ProductApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog(ConfigureSerikog)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void ConfigureSerikog(HostBuilderContext hostBuilderContext, LoggerConfiguration configuration)
        {

              var elasticUri = hostBuilderContext.Configuration.GetValue<string>("ElasticConfiguration:Uri");

              configuration
                   .Enrich.FromLogContext()
                   .Enrich.WithMachineName()
                   .WriteTo.Debug()
                   .WriteTo.Console()
                   .WriteTo.Elasticsearch(
                       new ElasticsearchSinkOptions(new Uri(elasticUri))
                       {
                           IndexFormat = $"applogs-{hostBuilderContext.HostingEnvironment.ApplicationName?.ToLower().Replace(".", "-")}-{hostBuilderContext.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                           AutoRegisterTemplate = true,
                           NumberOfShards = 2,
                           NumberOfReplicas = 1
                       })
                   .Enrich.WithProperty("Environment", hostBuilderContext.HostingEnvironment.EnvironmentName)
                   .Enrich.WithProperty("Application", hostBuilderContext.HostingEnvironment.ApplicationName)
                   .ReadFrom.Configuration(hostBuilderContext.Configuration);
          }
    }
}
