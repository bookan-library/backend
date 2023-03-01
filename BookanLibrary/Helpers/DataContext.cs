using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Newsletter;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Helpers
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.UseSerialColumns();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Manager>().ToTable("Managers");
            modelBuilder.Entity<Seller>().ToTable("Sellers");
            modelBuilder.Entity<Buyer>().ToTable("Buyers");
            
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Wish> WishLists { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
}
}
