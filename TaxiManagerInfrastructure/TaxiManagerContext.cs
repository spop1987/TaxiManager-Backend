using Microsoft.EntityFrameworkCore;
using TaxiManagerDomain.Entities;

namespace TaxiManagerInfrastructure
{
    public class TaxiManagerContext : DbContext
    {
        public TaxiManagerContext(DbContextOptions<TaxiManagerContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses {get; set;}
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
        
    }
}