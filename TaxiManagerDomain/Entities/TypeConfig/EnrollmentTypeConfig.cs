using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaxiManagerDomain.Entities.TypeConfig
{
    public class EnrollmentTypeConfig : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Driver).WithMany(u => u.Enrollments);
            builder.HasOne(e => e.Vehicle).WithMany(v => v.Enrollments);
            builder.Property(e => e.StartDate).HasColumnType("dateTime");
            builder.Property(e => e.EndDate).HasColumnType("dateTime");
        }
    }
}