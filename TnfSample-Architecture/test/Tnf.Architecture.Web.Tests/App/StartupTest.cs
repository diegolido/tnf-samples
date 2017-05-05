﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tnf.AspNetCore.TestBase;
using Tnf.AspNetCore;
using Tnf.Reflection.Extensions;
using Newtonsoft.Json.Serialization;

namespace Tnf.Architecture.Web.Tests.App
{
    public class StartupTest
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddApplicationPart(typeof(TnfAspNetCoreModule).GetAssembly())
                .AddApplicationPart(typeof(Tnf.Architecture.Web.Startup.WebModule).GetAssembly())
                .AddControllersAsServices();

            services.AddEntityFrameworkInMemoryDatabase();

            //Configure Tnf and Dependency Injection
            return services.AddTnf<AppTestModule>(options =>
            {
                //Test setup
                options.SetupTest();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseTnf(); //Initializes Tnf framework.

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
