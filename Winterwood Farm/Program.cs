﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Winterwood_Farm.Data;
using Microsoft.AspNetCore;

namespace Winterwood_Farm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        private static void CreateDbIfNotExists(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.EnsureCreated();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) => 
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                    logging.AddDebug();
                    logging.AddConsole();
                    // EventSource, EventLog, TraceSource, AzureAppServiceFile, AzureAppServiceBlob, ApplicationInsights
                })
                .UseStartup<Startup>();
        }
    }
}
