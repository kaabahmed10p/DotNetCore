using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.AspNetCore.Http;
using DataAccessPostgreSqlProvider;
using Microsoft.EntityFrameworkCore;
using DomainModel;
using Newtonsoft.Json;

namespace TodoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            //Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }   

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessPostgreSqlProvider");
			services.AddDbContext<DomainModelPostgreSqlContext>(options =>
				options.UseNpgsql(
					sqlConnectionString,
					b => b.MigrationsAssembly("TodoApi")
				)
			);
            services.AddScoped<IDataAccessProvider, DataAccessPostgreSqlProvider.DataAccessPostgreSqlProvider>();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.Map("/map1", HandleMapTest1);

            app.Use(async (context, next) =>
      {
            // Do work that doesn't write to the Response.
            await next.Invoke();
            // Do logging or other work that doesn't write to the Response.
        });

            app.Map("/map2", HandleMapTest2);

            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("Hello from non-Map delegate. <p>");
            // });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            RegisterNotFoundHandler(app);
        }

        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }

        private static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }

        private static void RegisterNotFoundHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Nothing Found!!! Should be converted to 404. <p>");
            });
        }
    }
}
