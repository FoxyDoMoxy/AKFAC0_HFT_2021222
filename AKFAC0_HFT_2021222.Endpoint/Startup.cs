using AKFAC0_HFT_2021222.Logic;
using AKFAC0_HFT_2021222.Logic.Classes;
using AKFAC0_HFT_2021222.Models;
using AKFAC0_HFT_2021222.Repository;
using AKFAC0_HFT_2021222.Repository.Interfaces;
using AKFAC0_HFT_2021222.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Endpoint
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<JobDbContext>();

			services.AddTransient<IRepository<Job>, JobRepository>();
			services.AddTransient<IRepository<Weapon>, WeaponRepository>();
			services.AddTransient<IRepository<Armor>, ArmorRepository>();

			services.AddTransient<IJobLogic, JobLogic>();
			services.AddTransient<IWeaponLogic, WeaponLogic>();
			services.AddTransient<IArmorLogic, ArmorLogic>();

			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "AKFAC0_HFT_2021222.Endpoint", Version = "v1" });
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AKFAC0_HFT_2021222.Endpoint v1"));
			}

			app.UseExceptionHandler(c => c.Run(async context =>
			{
				var exception = context.Features
					.Get<IExceptionHandlerPathFeature>()
					.Error;
				var response = new { Msg = exception.Message };
				await context.Response.WriteAsJsonAsync(response);
			}));

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapGet("/", async context =>
			//	{
			//		await context.Response.WriteAsync("Hello World!");
			//	});
			//});
		}
	}
}
