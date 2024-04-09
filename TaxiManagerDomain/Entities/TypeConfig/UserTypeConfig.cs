using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaxiManagerDomain.Entities.TypeConfig
{
    public class UserTypeConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.NationalId).IsRequired();
            builder.Property(u => u.FirstName).IsRequired().HasColumnType("varchar(100)");
            builder.Property(u => u.LastName).IsRequired().HasColumnType("varchar(100)");
            builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(100)");
            builder.Property(u => u.Password).IsRequired().HasColumnType("varchar(100)");
            builder.Property(u => u.UserType).HasColumnType("varchar(10)");
            builder.Property(u => u.CreateDate).HasColumnType("dateTime");
            builder.Property(u => u.UpdateDate).HasColumnType("dateTime");
            builder.Property(u => u.DeleteDate).HasColumnType("dateTime");
            builder.Property(u => u.Telephone).HasColumnType("varchar(12)");
            builder.HasMany(u => u.Addresses).WithOne(a => a.User).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Enrollments).WithOne(e => e.Driver).OnDelete(DeleteBehavior.Cascade);
        }
    }
}