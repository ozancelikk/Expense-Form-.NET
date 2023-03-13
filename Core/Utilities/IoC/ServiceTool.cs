using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceCollection Services { get; private set; }
        public static IHost Host;
        public static IServiceCollection CreateForMicrosoftDependencies(IServiceCollection services)
        {

            Services = services;
            ServiceProvider = services.BuildServiceProvider();


            //services.AddCors(opt =>
            //{
            //    opt.AddPolicy(name: "", builder =>
            //    {
            //        builder.WithOrigins("https://localhost:5011")
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });
            //    opt.AddPolicy(name: "", builder =>
            //    {
            //        builder.WithOrigins("https://localhost:5021")
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });
            //});
            return services;
        }

        public static IHost CreateForAutofac(IHostBuilder hostBuilder)
        {

            Host = hostBuilder.Build();

            return Host;
        }
        public static List<T> GetServiceList<T>(int serviceNumber)
        {
            List<T> services = new List<T>();
            for (int i = 0; i < serviceNumber; i++)
            {
                services.Add(Host.Services.GetService<T>());
            }
            return services;

        }
    }
}
