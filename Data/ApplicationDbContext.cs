using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public  ApplicationDbContext(DbContextOptions options):base(options){}

        public DbSet<Account> account { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<News> news { get; set; }

    }

}
