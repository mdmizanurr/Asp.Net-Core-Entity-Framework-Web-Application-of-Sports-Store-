using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class ServiceRepository : IServiceRepository
    {
        public SportDbContext context;

        public ServiceRepository(SportDbContext db)
        {
            context = db;
        }


        public IQueryable<Service> Services => context.Services;

    }
}
