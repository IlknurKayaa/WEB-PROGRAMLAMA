using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MakaleContext : DbContext
    {
        public DbSet<Makale> makales { get; set; }
        public DbSet<Kullanici> kullanicis { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=aa;Trusted_Connection=True;");
        }

    }
}
