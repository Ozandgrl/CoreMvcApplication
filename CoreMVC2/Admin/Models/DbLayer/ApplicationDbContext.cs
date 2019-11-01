using CoreMVC2.Admin.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Admin.Models.DbLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Catalog> Catalog { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Certificate> Certificate { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Machine> Machine { get; set; }
        public DbSet<New> New { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<RequestForm> RequestForm { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne<Catalog>(s => s.Catalog)
            .WithMany(g => g.Products)
            .HasForeignKey(s => s.CatalogId);
        }
    }
}
