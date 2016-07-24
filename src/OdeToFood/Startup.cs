using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OdeToFood.Services;
using Microsoft.AspNetCore.Routing;

namespace OdeToFood
{
    public class Startup
    {

		public Startup(IHostingEnvironment env) {
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json");
			Configuration = builder.Build();
		}

		public IConfiguration Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
        {
			services.AddSingleton(provider => Configuration);
			services.AddSingleton<IGreeter, Greeter>();
			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter)
        {
			app.UseRuntimeInfoPage("/info");
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseFileServer();
			app.UseMvc(ConfigureRoutes);
            app.Run(async (context) =>
            {
				var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }

		private void ConfigureRoutes(IRouteBuilder routeBuilder) {
			routeBuilder.MapRoute("Default", "{controller=home}/{action=index}/{id?}");
		}
	}
}
