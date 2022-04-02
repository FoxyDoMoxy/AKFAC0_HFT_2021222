using AKFAC0_HFT_2021222.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Endpoint
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//CreateHostBuilder(args).Build().Run();
			JobDbContext ctx = new JobDbContext();

			var jobs = ctx.Jobs.ToList();

			;
		}

		//public static IHostBuilder CreateHostBuilder(string[] args) =>
		//	Host.CreateDefaultBuilder(args)
		//		.ConfigureWebHostDefaults(webBuilder =>
		//		{
		//			webBuilder.UseStartup<Startup>();
		//		});
	}
}
