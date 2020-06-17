using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DOT_Net_Core.Models;
using Microsoft.EntityFrameworkCore;
using DOT_Net_Core.Repository;
using Infestation.Repositories;
using Microsoft.AspNetCore.Identity;
using Infestation.Infrastructure.Services.Interfaces;
using Infestation.Infrastructure.Services.Implementations;

namespace DOT_Net_Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INewsRepository, SqlNewsRepository>();
            services.AddScoped<IHumanActions, SqlHumanRepository>();
            services.AddControllersWithViews();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DOT_Net_CoreContext>();
            services.AddDbContext<DOT_Net_CoreContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("DOT_Net_CoreDbConnectionNew")).UseLazyLoadingProxies());
            //services.AddScoped<IMessageService, EmailMessageService>();
            services.AddScoped<IMessageService, SmsMessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
