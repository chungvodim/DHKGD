using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tearc.Portal.Data;
using Tearc.Portal.Models;
using Tearc.Portal.Services;
using Tearc.Repository.Main;
using Tearc.Entity.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.AspNetCore.Http;

namespace Tearc.Portal
{
    public class Startup
    {
        string _testSecret = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public Startup(IHostingEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder();

        //    if (env.IsDevelopment())
        //    {
        //        builder.AddUserSecrets<Startup>();
        //    }

        //    Configuration = builder.Build();
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MainDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TearcConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MainDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            // Requires all requests use HTTPS
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddMvc();

            _testSecret = Configuration["MySecret"];
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // redirects all HTTP requests to HTTPS:
            var options = new RewriteOptions().AddRedirectToHttps();
            app.UseRewriter(options);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            var result = string.IsNullOrEmpty(_testSecret) ? "Null" : "Not Null";
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Secret is {result}");
            });
        }
    }
}
