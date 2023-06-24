using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            base.Database.EnsureDeleted();
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // doctors

            var cabinet1 = new Cabinet()
            {
                Id = 1,
                NumberOfCab = "12"
            };

            var region1 = new Region()
            {
                Id = 1,
                NumberOfRegion = "123"
            };

            var specialty1 = new Specialty()
            {
                Id = 1,
                NameOfSpecialty = "therapiest"
            };

            modelBuilder.Entity<Cabinet>(b => { b.HasData(cabinet1); });
            modelBuilder.Entity<Specialty>(b => { b.HasData(specialty1); });
            modelBuilder.Entity<Region>(b => { b.HasData(region1); });

            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 1,
                FullName = "full name",
                CabinetId = 1,
                SpecialtyId = 1,
                RegionId = 1
            });

            var cabinet2 = new Cabinet()
            {
                Id = 2,
                NumberOfCab = "12"
            };

            var region2 = new Region()
            {
                Id = 2,
                NumberOfRegion = "123"
            };

            var specialty2 = new Specialty()
            {
                Id = 2,
                NameOfSpecialty = "therapiest"
            };

            modelBuilder.Entity<Cabinet>(b => { b.HasData(cabinet2); });
            modelBuilder.Entity<Specialty>(b => { b.HasData(specialty2); });
            modelBuilder.Entity<Region>(b => { b.HasData(region2); });

            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 2,
                FullName = "full name",
                CabinetId = 2,
                SpecialtyId = 2,
                RegionId = 2
            });

            //patients

            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = 1,
                Family = "family",
                FirstName = "FirstName",
                SecondName = "SecondName",
                Address = "Address",
                DateOfBirth = new DateTime(2004, 8, 21),
                Sex = false,
                RegionId = 1,
            });

            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = 2,
                Family = "family",
                FirstName = "FirstName",
                SecondName = "SecondName",
                Address = "Address",
                DateOfBirth = new DateTime(2000, 5, 21),
                Sex = true,
                RegionId = 2,
            });
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
    }
}
