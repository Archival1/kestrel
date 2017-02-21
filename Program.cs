using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
//TODO: Learn dependency injection, the above is incorrect as DI is the namespace.

namespace ConsoleApplication
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			var routeBuilder = new RouteBuilder(app);
			//Assign routes
			routeBuilder.MapGet("",context => context.Response.WriteAsync("Get response"));
			routeBuilder.MapGet("hello/{name}",context => context.Response
				.WriteAsync($"Hello, {context.GetRouteValue("name")}"));
			//Set the router usage
			app.UseRouter(routeBuilder.Build());
			/*app.Run(context =>
			{
				var response = String.Format("ayy {0}",DateTime.Now);
				return context.Response.WriteAsync(response);
			});*/
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRouting();
		}
	}
    public class Program
    {
        public static void Main(string[] args)
        {
	    Console.WriteLine("Running demo with Kestrel.");

		//This is our webhostBuiler
	    var builder = new WebHostBuilder()
		//.UseContentRoot(Directory.GetCurrentDirectory())
		.UseStartup<Startup>()
		.UseKestrel()
		.UseUrls("http://localhost:5000");
		//Build the webhost
	    var host = builder.Build();
		//run
	    host.Run();
        }
    }
}
