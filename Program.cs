using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ConsoleApplication
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.Run(context =>
			{
				var response = String.Format("ayy {0}",DateTime.Now);
				return context.Response.WriteAsync(response);
			});
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
