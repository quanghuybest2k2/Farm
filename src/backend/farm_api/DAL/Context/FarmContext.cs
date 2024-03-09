using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace DAL.Context
{
    public class FarmContext:DbContext
    {
        public FarmContext(DbContextOptions options) : base(options) { }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Core.Entities.Environment> Environments { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().HasKey(x => x.Id);
            modelBuilder.Entity<Core.Entities.Environment>().HasKey(x => x.Id);
            modelBuilder.Entity<Camera>().HasKey(x => x.Id);
            modelBuilder.Entity<Statistics>().HasKey(x => x.Id);


            base.OnModelCreating(modelBuilder);
        }


    }
}
