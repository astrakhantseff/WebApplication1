using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cabinet>(o =>
            {
                var cabinet = new Cabinet()
                {
                    Id = 3,
                    NumberOfCab = "12"
                };

                var region = new Region()
                {
                    Id = 3,
                    NumberOfRegion = "123"
                };

                var specialty = new Specialty()
                {
                    Id = 3,
                    NameOfSpecialty = "therapiest"
                };

                modelBuilder.Entity<Cabinet>(b => { b.HasData(cabinet); });
                modelBuilder.Entity<Specialty>(b => { b.HasData(specialty); });
                modelBuilder.Entity<Region>(b => { b.HasData(region); });

                modelBuilder.Entity<Doctor>().HasData(new Doctor
                {
                    Id = 3,
                    FullName = "full name",
                    CabinetId = 3,
                    SpecialtyId = 3,
                    RegionId = 3
                });
            });
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
    }
}
