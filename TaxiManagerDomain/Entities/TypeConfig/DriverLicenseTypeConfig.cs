using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaxiManagerDomain.Entities.TypeConfig
{
    public class DriverLicenseTypeConfig : IEntityTypeConfiguration<DriverLicense>
    {
        public void Configure(EntityTypeBuilder<DriverLicense> builder)
        {
            builder.ToTable("DriverLicense");
            builder.HasKey(dl => dl.Id);
            builder.Property(dl => dl.Number).IsRequired().HasColumnType("varchar").HasMaxLength(10);
            builder.Property(dl => dl.Category).IsRequired().HasColumnType("varchar").HasMaxLength(10);
            builder.Property(dl => dl.ExpeditionDate).HasColumnType("dateTime");
            builder.Property(dl => dl.ExpiredDate).HasColumnType("dateTime");
            builder.Property(dl => dl.CreateDate).HasColumnType("dateTime");
            builder.Property(dl => dl.UpdateDate).HasColumnType("dateTime");
            builder.Property(dl => dl.DeleteDate).HasColumnType("dateTime");
        }
    }
}