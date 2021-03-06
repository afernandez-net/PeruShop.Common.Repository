using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeruShop.Common.Repository;
using PeruShop.Services.Customers.Domain;
using PeruShop.Services.Customers.Infrastructure;
using PeruShop.Services.Customers.Repositories;
using System;

namespace PeruShop.Services.Customers
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
            services.AddDbContext<CustomersDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Customers")));
            //services.AddDbContext<CustomersDbContext>(x => x.UseInMemoryDatabase("Customers"));

            services.AddRepository<CustomersDbContext>()
                .RepositoryOptions<Customer>(x => x.Seed = CustomersDbContextSeed.Customers)
                .RepositoryOptions<Order>(x => x.Seed = CustomersDbContextSeed.Orders)
                .RepositoryOptions<OrderItem>(x => x.Seed = CustomersDbContextSeed.OrderItems);

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}