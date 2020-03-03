using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class StoreIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options) 
            : base(options) { }




    }
}
