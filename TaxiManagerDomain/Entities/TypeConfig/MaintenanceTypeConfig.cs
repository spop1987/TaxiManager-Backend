using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiManagerDomain.Shared;

namespace TaxiManagerDomain.Entities.TypeConfig
{
    public class MaintenanceTypeConfig : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.ToTable("Maintenance");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.VehicleMileage).IsRequired();
            builder.Property(m => m.Description).IsRequired().HasColumnType("varchar(500)");
            builder.Property(m => m.StartDate).IsRequired().HasColumnType("dateTime");
            builder.Property(m => m.EndDate).IsRequired().HasColumnType("dateTime");
            builder.Property(m => m.IsRepair);
            builder.OwnsOne(m => m.TotalPrice, priceBuilder => 
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code)).HasColumnType("varchar(3)");
            });
            builder.OwnsOne(m => m.LaborPrice, priceBuilder => 
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code)).HasColumnType("varchar(3)");
            });
            builder.HasOne(m => m.WhereItWasMade).WithOne(a => a.Maintenance).HasForeignKey<Address>(a => a.MaintenanceId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(m => m.Vehicle).WithMany(v => v.Maintenances).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.AutoParts).WithOne(au => au.Maintenance).OnDelete(DeleteBehavior.Cascade);
        }
    }
}