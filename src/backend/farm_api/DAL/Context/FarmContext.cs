using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace DAL.Context
{
    public class FarmContext : DbContext
    {
        public FarmContext(DbContextOptions options) : base(options) { }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Core.Entities.Environment> Environments { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Farm> Farms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //config table farm
            modelBuilder.Entity<Device>().HasKey(x => x.Id);
            modelBuilder.Entity<Core.Entities.Environment>().HasKey(x => x.Id);
            modelBuilder.Entity<Camera>().HasKey(x => x.Id);
            modelBuilder.Entity<Farm>().HasKey(x => x.Id);

            // config table farm
            modelBuilder.Entity<Farm>().HasMany(x => x.Devices)
                .WithOne(x => x.Farm)
                .HasForeignKey(x => x.FarmId)
                .OnDelete(DeleteBehavior.Cascade);

            // set relationship between Tables Farm and environment
            modelBuilder.Entity<Farm>().HasMany(f=>f.Environments)
                .WithOne(e=>e.Farm)
                .HasForeignKey(e => e.SensorLocation)
                .HasPrincipalKey(f => f.SensorLocation)
                .OnDelete(DeleteBehavior.Cascade);

            //set sensorlocation is unique
            modelBuilder.Entity<Farm>()
                .HasIndex(u => u.SensorLocation)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
