using Microsoft.EntityFrameworkCore;
using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Entities.TypeConfig;

namespace TaxiManagerInfrastructure
{
    public class TaxiManagerContext : DbContext
    {
        public TaxiManagerContext(DbContextOptions<TaxiManagerContext> options) : base(options) {}

        public DbSet<Address> Addresses {get; set;}
        public DbSet<AutoPart> AutoParts { get; set; }
        public DbSet<DriverLicense> DriverLicenses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
             modelBuilder.ApplyAllTypeConfiguration();
        }
        
    }
}