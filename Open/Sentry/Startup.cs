﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Domain.Party;
using Open.Domain.Quantity;
using Open.Infra;
using Open.Infra.Bank;
using Open.Infra.Party;
using Open.Infra.Quantity;
using Open.Sentry.Data;
using Open.Sentry.Models;
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
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();
            setAuthentication(services);
            services.AddTransient<IEmailSender, EmailSender>();
            setMvcWithAntyFoggeryToken(services);
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<ICurrencyRepository, CurrenciesRepository>();
            services.AddScoped<INationalCurrenciesRepository, NationalCurrenciesRepository>();
            services.AddScoped<IAddressesRepository, ContactsRepository>();
            services.AddScoped<ITelecomDeviceRegistrationsRepository, TelecomDeviceRegistrationsRepository>();
            services.AddScoped<IRateTypeRepository, RateTypesRepository>();
            services.AddScoped<IRateRepository, RatesRepository>();
            services.AddScoped<IPaymentMethodsRepository, PaymentMethodsRepository>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            //        services.AddScoped<IClientsRepository, ClientsRepository>();
        }

        protected virtual void setMvcWithAntyFoggeryToken(IServiceCollection services) {
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        }

        protected virtual void setAuthentication(IServiceCollection services) { }
        protected virtual void setDatabase(IServiceCollection services) {
            var s = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(s));
            services.AddDbContext<SentryDbContext>(
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
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else { app.UseExceptionHandler("/Home/Error"); }
        }
    }
}

