using Microsoft.EntityFrameworkCore;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Product> products {  get; set; }
        public DbSet<Order> orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=ProductsOrders; Trusted_Connection=true; TrustServerCertificate=true;");
        }
    }
}
