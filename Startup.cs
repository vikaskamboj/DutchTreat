using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Services;
using DutchTreat.Data;
using Microsoft.EntityFrameworkCore;

namespace DutchTreat
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DutchContext>();
			services.AddTransient<DutchSeeder>();
			services.AddScoped<IDutchRepository, DutchRepository>();
			services.AddTransient<IMailService, NullMailService>();
			services.AddControllersWithViews();
			services.AddRazorPages();
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else {
				app.UseExceptionHandler("/error");
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(cfg => {
				cfg.MapRazorPages();

				cfg.MapControllerRoute("Default",
				 "{controller}/{action}/{id?}",
				 new { controller = "App", action = "Index" });
				});
		}
	}
}
