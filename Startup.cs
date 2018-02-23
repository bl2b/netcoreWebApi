using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace netcoreWebApi
{
    /// <summary>
    /// Entry point of our web application
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// used to add services to the container for DI, and to configure those services
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .AddMvcOptions(x => x.OutputFormatters.Add(
                new XmlDataContractSerializerOutputFormatter()));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// used to specify how an asp.net applciation will respond to individual http request
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment()) //you can change this on launch.json
            {
                app.UseDeveloperExceptionPage() ;
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseMvc();

            // app.Run((context) => {
            //     throw new Exception("Test");
            // });

            // app.Run(async (context) => {
            //     await context.Response.WriteAsync("Hello World");
            // });
        }
    }
}
