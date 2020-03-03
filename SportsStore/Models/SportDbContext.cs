using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class SportDbContext : DbContext
    {
        public SportDbContext()
        {
        }

        public SportDbContext(DbContextOptions<SportDbContext> options) : base(options) { }

        //private const string ConnectionString = @"Server=MIZAN\\MIZANSQL;Database=SportsStore;Trusted_Connection=True";

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionString);
        //}



        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }




    }
}
