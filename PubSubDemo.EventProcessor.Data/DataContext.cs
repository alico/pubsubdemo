using Microsoft.EntityFrameworkCore;
using PubSubDemo.EventProcessor.Data.Contract;
using PubSubDemo.EventProcessor.Data.Entity;
using PubSubDemo.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubDemo.EventProcessor.Data
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly ConnectionStrings _connectionStrings;

        public DataContext(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public void EnsureDbCreated()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStrings.Main);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
        }

        public DbSet<Product> Products { get; set; }
    }
}
