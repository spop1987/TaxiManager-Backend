using Microsoft.EntityFrameworkCore;

namespace TaxiManagerDomain.Entities.TypeConfig
{
    public static class Extension
    {
        public static void ApplyAllTypeConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressTypeConfig());
            modelBuilder.ApplyConfiguration(new AutoPartTypeConfig());
            modelBuilder.ApplyConfiguration(new DriverLicenseTypeConfig());
            modelBuilder.ApplyConfiguration(new EnrollmentTypeConfig());
            modelBuilder.ApplyConfiguration(new MaintenanceTypeConfig());
            modelBuilder.ApplyConfiguration(new UserTypeConfig());
            modelBuilder.ApplyConfiguration(new VehicleTypeConfig());
        }
    }
}