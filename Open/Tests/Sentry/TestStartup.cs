using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Open.Infra.Money;
using Open.Infra.Party;
using Open.Infra.Quantity;
using Open.Infra.Rule;
using Open.Sentry;
using Open.Sentry.Data;
namespace Open.Tests.Sentry {

    public class TestStartup : Startup {

        public const string Testing = "Testing";

        public TestStartup(IConfiguration configuration) : base(configuration) { }

        protected override void setDatabase(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(Testing));
            services.AddDbContext<MoneyDbContext>(
                options => options.UseInMemoryDatabase(Testing));
            services.AddDbContext<QuantityDbContext>(
                options => options.UseInMemoryDatabase(Testing));
            services.AddDbContext<PartyDbContext>(
                options => options.UseInMemoryDatabase(Testing));
            services.AddDbContext<RulesDbContext>(
                options => options.UseInMemoryDatabase(Testing));
        }

        protected override void setAuthentication(IServiceCollection services) {
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "Test Scheme";
                options.DefaultChallengeScheme = "Test Scheme";
            }).AddTestAuth(o => { });
        }

        protected override void setMvcWithAntyFoggeryToken(IServiceCollection services)
        {
            services.AddMvc(options =>options.Filters.Add(new AntiForgeryAttributeTest()));
        }

        protected override void setErrorPage(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        }
    }
}

