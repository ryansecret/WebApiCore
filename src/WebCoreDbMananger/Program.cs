using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiCore.DomainModel.WebApiCore;

namespace WebCoreDbMananger
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }


    
    public class RyanContext : DbContext
    {

 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebCoreTest;Trusted_Connection=True;");
        }

        public DbSet<BallEntity> Ball { get; set; }
    }
}
