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
using Infestation.Infrastructure.Configuration;
using Microsoft.AspNetCore.Http;
using Infestation.Infrastructure.Middlewares;
using Infestation.Infrastructure.BackgroundServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

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
            services.AddSingleton<IMessageService, MessageService>();
            services.AddSingleton<IExampleRestClient, ExampleRestClient>();
            services.AddSingleton<FileProcessingChannel>();

            services.AddDbContext<DOT_Net_CoreContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("DOT_Net_CoreDbConnectionNew")).UseLazyLoadingProxies());
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DOT_Net_CoreContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddMemoryCache();
            services.AddHostedService<LoadFileService>();
            services.AddHostedService<UploadFileService>();

            var section = Configuration.GetSection("Infestation");
            services.Configure<InfestationConfiguration>(section);

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

            services.AddControllersWithViews(configure =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });







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

            app.UseMiddleware<SendRequestNotificationMiddleWare>();

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("This is middleware");

            //}
            //);

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is middleware");
            //    await next.Invoke();

            //}
            //);

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
