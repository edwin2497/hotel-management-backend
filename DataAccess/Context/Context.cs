using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source= EDWIN-PC;Initial Catalog= HotelManagement; User Id= Test ; Password = 123");
            }
        }

        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<Room> Room { get; set; }

        public virtual DbSet<Reservation> Reservation { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }


    }
}
