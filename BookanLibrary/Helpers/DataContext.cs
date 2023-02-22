﻿using BookanLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<Manager>().ToTable("Managers");
            modelBuilder.Entity<Seller>().ToTable("Sellers");
            modelBuilder.Entity<Buyer>().ToTable("Buyers");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Address> Addresses { get; set; }
}
}