using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaxiManagerDomain.Entities.TypeConfig
{
    public class VehicleTypeConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Registration).IsRequired().HasColumnType("varchar(10)");
            builder.Property(v => v.VehicleType).HasColumnType("varchar(10)");
            builder.Property(v => v.Brand).HasColumnType("varchar(10)");
            builder.Property(v => v.Model).HasColumnType("varchar(10)");
            builder.Property(v => v.Year).HasColumnType("varchar(4)");
            builder.Property(v => v.Nickname).HasColumnType("varchar(20)");
            builder.Property(v => v.CreateDate).HasColumnType("dateTime");
            builder.Property(v => v.UpdateDate).HasColumnType("dateTime");
            builder.Property(v => v.DeleteDate).HasColumnType("dateTime");
            builder.HasMany(v => v.Enrollments).WithOne(e => e.Vehicle).OnDelete(DeleteBehavior.Cascade);
        }
    }
}