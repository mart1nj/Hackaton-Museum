﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Open.Data.User;
using Open.Domain.Museum;
using Open.Infra;
using Open.Infra.Museum;
using Open.Sentry.Services;

namespace Open.Sentry {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            setDatabase(services);
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            setAuthentication(services);
            services.AddTransient<IEmailSender, EmailSender>();
            setMvcWithAntiForgeryToken(services);
            services.AddScoped<IMusealsRepository, MusealsRepository>();
            services.AddScoped<IInventoriesRepository, InventoriesRepository>();
            services.AddScoped<IInventoryMusealsRepository, InventoryMusealsRepository>();
        }

        protected virtual void setMvcWithAntiForgeryToken(IServiceCollection services) {
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        }

        protected virtual void setAuthentication(IServiceCollection services) { }

        protected virtual void setDatabase(IServiceCollection services) {
            var s = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(s));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            setErrorPage(app, env);
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        protected virtual void setErrorPage(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }
        }
    }
}
