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
using Newtonsoft.Json.Serialization;
using XYC.Domain.Abstract.Sample;
using XYC.Domain.Concrete.Sample;

namespace netcoreWebApi
{
    /// <summary>
    /// Entry point of our web application
    /// </summary>
    public class Startup
    {

        public static IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// used to add services to the container for DI, and to configure those services
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .AddMvcOptions(x => x.OutputFormatters.Add( // this support the Formatters and Content
                new XmlDataContractSerializerOutputFormatter()));

            // .AddJsonOptions(o =>{ // this for json return convention. to return the object starts with capital letter
            //     if(o.SerializerSettings.ContractResolver != null)
            //     {
            //         var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
            //         castedResolver.NamingStrategy = null;
            //     }                
            // });

            #if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#           else
            services.AddTransient<IMailService, CloudMailService>();
            #endif
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// used to specify how an asp.net applciation will respond to individual http request
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // No need to add these loggers in ASP.NET Core 2.0: the call to WebHost.CreateDefaultBuilder(args) 
            // in the Program class takes care of that.

            //loggerFactory.AddConsole();
            //loggerFactory.AddDebug();

            //loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
            loggerFactory.AddNLog();

            if (env.IsDevelopment()) //you can change this on launch.json
            {
                app.UseDeveloperExceptionPage() ;
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages(); // show status code on the browser
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
