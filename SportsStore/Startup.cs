using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SportsStore.Models;

namespace SportsStore
{
    public class Startup
    {

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SportDbContext>
                (options => options.UseSqlServer
                (Configuration["Data:SportStoreProducts:ConnectionString"]));

            services.AddDbContext<StoreIdentityDbContext>(options =>
                options.UseSqlServer(
                Configuration["Data:SportsStoreIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<StoreIdentityDbContext>()
                .AddDefaultTokenProviders();


            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.TryAddSingleton<HttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>(); //Test add
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            //Routing configuration 
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: null,
                    template: "{catagory}/Page{productPage:int}",
                    defaults: new { Controller = "Product", action = "List" });

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { Controller = "Product", action = "List", productPage =1 });


                routes.MapRoute(
                      name: "pagination",
                      template: "Products/Page(productPage)",
                      defaults: new { controller = "Product", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });

            SeedData.EnsureAdd(app);
            IdentitySeedData.EnsurePopulated(app);

        }
    }
}
