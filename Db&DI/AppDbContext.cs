using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Db_DI
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Database.SetCommandTimeout(TimeSpan.FromMinutes(3));
            //_connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<user> user {  get; set; }
    }
}
    
