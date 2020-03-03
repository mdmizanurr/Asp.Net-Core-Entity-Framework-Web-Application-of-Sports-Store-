using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class SeedData
    {
        public static void EnsureAdd(IApplicationBuilder app)
        {
            SportDbContext context = app.ApplicationServices.GetRequiredService<SportDbContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one persion",
                        Category = "Watersports",
                        Price = 440
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and Fashioable",
                        Category = "Watersports",
                        Price = 12.5M
                    },
                    new Product
                    {
                        Name = "Socer Ball",
                        Description = "Fifa-approved size and weight",
                        Category = "Ball",
                        Price = 20.75M
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
