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
            builder.Property(u => u.FirstName).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(u => u.DateOfBirth).HasColumnType("dateTime");
            builder.Property(u => u.Email).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(u => u.CreateDate).HasColumnType("dateTime");
            builder.Property(u => u.UpdateDate).HasColumnType("dateTime");
            builder.Property(u => u.DeleteDate).HasColumnType("dateTime");
            builder.Property(u => u.Telephone).HasColumnType("varchar").HasMaxLength(12);
            builder.HasIndex(u => u.NationalId, "IX_User_NationalId").IsUnique();
            builder.HasMany(u => u.Addresses).WithOne(a => a.User).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Enrollments).WithOne(e => e.Driver).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(u => u.DriverLicense).WithOne(d => d.Driver).HasForeignKey<DriverLicense>(d => d.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Roles).WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    role => role.HasOne<Role>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_UserRole_RoleId").OnDelete(DeleteBehavior.Cascade),
                    user => user.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_UserRole_UserId").OnDelete(DeleteBehavior.Cascade) 
                );
        }
    }
}