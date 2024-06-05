using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace real_estate_app.Models
{
    
        public class AppDbContext : DbContext
        {

            public DbSet<RealEstateInventory> RealEstateInventory { get; set; }
            public DbSet<RealEstate> RealEstate { get; set; }
            public DbSet<Seller> Seller { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=taha\\MSSQLSERVER01;Database=odev2;Encrypt=false;Trusted_Connection=True;");

        }
    }
    
}
