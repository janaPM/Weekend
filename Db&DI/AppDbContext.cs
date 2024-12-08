using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Db_DI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            this.Database.SetCommandTimeout(TimeSpan.FromMinutes(3));

        }


        public DbSet<User> user {  get; set; }
    }
}
    
