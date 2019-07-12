using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POSmvc.Models;
using Microsoft.EntityFrameworkCore;

namespace POSmvc.Data
{
    public class PosContext : DbContext
    {
        public PosContext(DbContextOptions<PosContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }
        //overrite default plural name
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Sales>().ToTable("Sales");
            modelBuilder.Entity<SalesDetail>().ToTable("SalesDetail");
        }
        //overrite default plural name
        public DbSet<POSmvc.Models.MakeSales> MakeSales { get; set; }
    }
}
