using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Wpf.Object;

namespace Wpf.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<ComponentWarehouse> ComponentWarehouse { get; set; }
        public DbSet<ListComponent> ListComponent { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Username=postgres;Password=123;Database=123123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ComponentWarehouse>().HasOne(p => p.Category)
                                                     .WithMany(p => p.ComponentWarehouses);

            modelBuilder.Entity<ListComponent>().HasOne(p => p.ComponentWarehouse)
                                                .WithMany(p => p.ListComponents);

            modelBuilder.Entity<ListComponent>().HasOne(p => p.Order)
                                                .WithMany(p => p.ListComponent);

            modelBuilder.Entity<Order>().HasOne(p => p.UserEntity)
                                                .WithMany(p => p.OrderEntity);
        }


    }
}
